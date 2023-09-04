using ChopShop.Api.Configuration;
using ChopShop.Api.Dal.Postgres.Context;
using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddPostgresContext(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PostgresContext postgresContext)
    {
        // if (postgresContext.Database.GetPendingMigrations().Any())
        //     postgresContext.Database.Migrate();
        
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseCors(cfg => cfg.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "default",
                "{controller}");
        });
        
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}