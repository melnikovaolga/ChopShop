using ChopShop.Api.Dal.MenuContext;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Configuration;

public static class PostgresConfiguration
{
    public static void AddMenuDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<MenuContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Menu"),
                option => { option.MigrationsAssembly("ChopShop.Api.Dal.MenuContext"); });
        });
    
    public static void AddUserDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<MenuContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("User"),
                option => { option.MigrationsAssembly("ChopShop.Api.Dal.UserContext"); });
        });
}