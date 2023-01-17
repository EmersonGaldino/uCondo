using MongoDB.Driver;
using showMeMicroservice.domain.Repositories.IRepository.Base;
using showMeMicroservice.infraestruct.Infraestruct.Application;
using showMeMicroservice.infraestruct.Infraestruct.Base;
using showMeMicroservice.infraestruct.Infraestruct.Mongo;

namespace showMeMicroservice.repository.Configuration;

public class Context : IMongoContext
{
    #region .::Constructor

    private IMongoDatabase Database { get; set; }
    public IClientSessionHandle Session { get; set; }
    public MongoClient MongoClient { get; set; }
    public MongoClientSettings MongoClientSettings { get; set; }
    private readonly List<Func<Task>> commands;
    private readonly MongoConfig mongoConfig;
    private readonly ApplicationConfig applicationConfig;

    #endregion


    #region .::Methods

    public Context(InfraestructConfig infrastructureConfig)
    {
        this.mongoConfig = infrastructureConfig.MongoConfig;
        this.commands = new List<Func<Task>>();
        applicationConfig = infrastructureConfig.ApplicationConfig;
        this.ConfigureMongo();
    }


    public async Task<int> SaveChanges()
    {
        //ConfigureMongo();


        using (Session = await MongoClient.StartSessionAsync())
        {
            Session.StartTransaction();


            var commandTasks = commands.Select(c => c());


            await Task.WhenAll(commandTasks);


            await Session.CommitTransactionAsync();
        }


        return commands.Count;
    }


    private void ConfigureMongo()
    {
        MongoClientSettings = new MongoClientSettings
        {
            Server = new MongoServerAddress(mongoConfig.Connection, mongoConfig.Port),
            ReplicaSetName = "RS-Vision",
            Credential = new MongoCredential("SCRAM-SHA-1", 
                new MongoInternalIdentity(mongoConfig.DataBaseName,mongoConfig.UserName),new PasswordEvidence(mongoConfig.Password))
        };
        MongoClient = new MongoClient(mongoConfig.Connection);
        Database = MongoClient.GetDatabase(mongoConfig.DataBaseName);
    }


    public IMongoCollection<T> GetCollection<T>(string name)
    {
        var newName = "";
        //ConfigureMongo();

        if (name.Contains("Schema"))
            newName = name.Split("Schema")[0];
        return Database.GetCollection<T>(newName != "" ? newName.ToLower() : name);
    }

    public void Dispose()
    {
        while (Session?.IsInTransaction == true)
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        GC.SuppressFinalize(this);
    }

    public void AddCommand(Func<Task> func)
    {
        commands.Add(func);
    }

    #endregion
}