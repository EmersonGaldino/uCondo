using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uCondo.Galdino.Application.AppService.User;
using uCondo.Galdino.Application.Interface.User;
using uCondo.Galdino.BootStraper.Configurations.Performace.Filters;
using uCondo.Galdino.Domain.Interface.User;
using uCondo.Galdino.Domain.Repositories.IService.User;
using uCondo.Galdino.Domain.Service.User;
using uCondo.Galdino.Repository.Repository.Context;
using uCondo.Galdino.Repository.Repository.User;

namespace uCondo.Galdino.BootStraper.Configurations.Injections;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {


        #region .::Include injection configurations estructure
        // var infraConfig = new InfraestructConfig();
        // new ConfigureFromConfigurationOptions<InfraestructConfig>(
        //         configuration.GetSection("Infrastructure"))
        //     .Configure(infraConfig);
        // services.AddSingleton(infraConfig);
        #endregion

        #region .:: Include ConnectionString
        //services.AddScoped<IConnectionPostgres, UnitOfWorkPostgres>(x => new UnitOfWorkPostgres(new RouterEnvironments().GetEnvByName("SqlConnectionStringIzacore")));

        //new RouterEnvironments().GetEnvByName("SqlConnectionString")

        //services.AddScoped<IConnectionHooksReturn, UnitOfWorkHooksReturn>(x => new UnitOfWorkHooksReturn(new RouterEnvironments().GetEnvByName("SqlConnectionString")));
        #endregion

        #region .:: Configuration filter performace

        services.AddTransient<PerformaceFilters>();
        services.AddMvc(options => options.Filters.AddService<PerformaceFilters>())
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        #endregion


        #region .::AppServices
        
        services.AddScoped<IUserAppService, UserAppService>();
        #endregion
        
        #region .::Services
        services.AddScoped<IUserService, UserService>();
        #endregion
        
        #region .::Repositories
        services.AddScoped<IUserRepository,UserRepository>();
        #endregion
        
        #region .::UnitOfWork
        
        services.AddScoped<uCondoContext>();
        #endregion


        return services;
    }  
    
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var getEnv = Environment.GetEnvironmentVariable("ENVIRONMENT"); // Caso queira utilizar varialve de ambiente

        if (getEnv is "Development" or null)
        {
            var teste = configuration.GetConnectionString("uCondoConn");
            services.AddDbContext<uCondoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("uCondoConn")));
        }
        else
        {

            services.AddDbContext<uCondoContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("uCondoConn")!));
        }

    }
    
}