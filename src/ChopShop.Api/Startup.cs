using ChopShop.Api.Configuration;
using ChopShop.Api.Dal.MenuContext;
using ChopShop.Api.Dal.UserContext;
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
        services.AddUserDbContext(Configuration);
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MenuContext menuContext, UserContext userContext)
    {
        if (menuContext.Database.GetPendingMigrations().Any())
            menuContext.Database.Migrate();
        
        if (userContext.Database.GetPendingMigrations().Any())
            userContext.Database.Migrate();
        
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