using ChopShop.Api.Dal.Postgres;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Configuration;

public static class PostgresConfiguration
{
    public static void AddMenuDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<MenuDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("NpgConnection"),
                option => { option.MigrationsAssembly("ChopShop.Api.Dal.Postgres"); });
        });
}