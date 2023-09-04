using ChopShop.Api.Dal.Postgres.Context;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Configuration;

public static class PostgresConfiguration
{
    public static void AddPostgresContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<PostgresContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("NpgConnection"),
                option => { option.MigrationsAssembly("ChopShop.Api.Dal.Postgres"); });
        });
}