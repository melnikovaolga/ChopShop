using ChopShop.Api.Configuration;
using ChopShop.Api.Dal.MenuContext;
using ChopShop.Api.Dal.UserContext;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
            });
        
        services.AddControllersWithViews();
        
        //services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MenuContext menuContext, UserContext userContext)
    {
        if (menuContext.Database.GetPendingMigrations().Any())
            menuContext.Database.Migrate();
        
        if (userContext.Database.GetPendingMigrations().Any())
            userContext.Database.Migrate();
        
        app.UseDeveloperExceptionPage();
        app.UseStaticFiles();

        app.UseRouting();
        //app.UseHttpsRedirection();
        
        app.UseAuthentication();
        app.UseAuthorization(); 
        
        //app.UseCors(cfg => cfg.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Menu}/{action=Get}/{id?}");
        });
        
        //app.UseSwagger();
        //app.UseSwaggerUI();
    }
}