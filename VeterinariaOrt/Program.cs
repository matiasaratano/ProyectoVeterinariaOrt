using Microsoft.EntityFrameworkCore;
using VeterinariaOrt.Models;
using VeterinariaOrt.Servicios.Contrato;
using VeterinariaOrt.Servicios.Implementacion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();
        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
        builder.Services.AddSession();


        builder.Services.AddDbContext<VeterinariaContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
        });

        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Inicio/IniciarSesion";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
                options.Cookie.Name = ".AdventureWorks.Session";

            }
            );

        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add(
                new ResponseCacheAttribute
                {
                    NoStore = true,
                    Location = ResponseCacheLocation.None,
                });

        });



        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

      
        app.UseSession();

        //el controlador de inicio
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        //pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

        app.Run();
    }
}