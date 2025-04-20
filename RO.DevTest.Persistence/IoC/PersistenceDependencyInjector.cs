using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RO.DevTest.Persistence.IoC;

public static class PersistenceDependencyInjector {
    /// <summary>
    /// Injetar as dependências da camada de persistência em um
    /// <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">
    /// O <see cref="IServiceCollection"/> para injetar as dependências
    /// </param>
    /// <param name="configuration">
    /// O objeto de configuração para obter a string de conexão
    /// </param>
    /// <returns>
    /// O <see cref="IServiceCollection"/> com as dependências injetadas
    /// </returns>
     public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISaleProductRepository, SaleProductRepository>();

        return services;
    }
}
