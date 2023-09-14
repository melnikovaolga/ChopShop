using ChopShop.Api.Configuration;
using ChopShop.Api.Dal.Postgres;
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
        services.AddMenuDbContext(Configuration);
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MenuDbContext menuDbContext)
    {
        if (menuDbContext.Database.GetPendingMigrations().Any())
            menuDbContext.Database.Migrate();
        
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