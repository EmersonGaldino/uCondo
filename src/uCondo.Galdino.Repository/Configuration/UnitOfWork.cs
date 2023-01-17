using showMeMicroservice.domain.Repositories.IRepository.Base;
using showMeMicroservice.infraestruct.UnitOfWork;

namespace showMeMicroservice.repository.Configuration;

public class UnitOfWork : IUnitOfWork
{
    #region .::Constructor

    private readonly IMongoContext context;


    public UnitOfWork(IMongoContext context)
    {
        this.context = context;
    }

    #endregion
    
    #region .::Methods

    public async Task<bool> Commit() =>
        await context.SaveChanges() > 0;
    
    public void Dispose() => context.Dispose();

    #endregion
}