using BookingSystem.Domain.Repositories.User;
using BookingSystem.Infrastructure.DataAccess;
using BookingSystem.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Infrastructure;
public static class DepedencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var connectionString = "Data Source=(local);Initial Catalog=BookingSystem;User ID=sa;Password=Ca123xcv@!;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        
        services.AddDbContext<BookingSystemDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseSqlServer(connectionString);
        });
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}
