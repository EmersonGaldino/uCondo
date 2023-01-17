using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using uCondo.Galdino.Application.AppService.Account;
using uCondo.Galdino.Application.AppService.User;
using uCondo.Galdino.Application.Interface.Account;
using uCondo.Galdino.Application.Interface.User;
using uCondo.Galdino.BootStraper.Configurations.Performace.Filters;
using uCondo.Galdino.BootStraper.Configurations.Security;
using uCondo.Galdino.Domain.Interface.Account;
using uCondo.Galdino.Domain.Interface.User;
using uCondo.Galdino.Domain.Repositories.IService.Account;
using uCondo.Galdino.Domain.Repositories.IService.User;
using uCondo.Galdino.Domain.Service.Account;
using uCondo.Galdino.Domain.Service.User;
using uCondo.Galdino.Repository.Repository.Account;
using uCondo.Galdino.Repository.Repository.Context;
using uCondo.Galdino.Repository.Repository.User;

namespace uCondo.Galdino.BootStraper.Configurations.Injections;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region .::Include injection configurations token

        var tokenConfig = new TokenConfig();
        new ConfigureFromConfigurationOptions<TokenConfig>(configuration.GetSection("TokenConfig"))
            .Configure(tokenConfig);
        services.AddSingleton(tokenConfig);

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
        services.AddScoped<IAccountAppService, AccountAppService>();

        #endregion

        #region .::Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();

        #endregion

        #region .::Repositories

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

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