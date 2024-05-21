using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Persistance;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "LoginCokiee";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });

builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// || AREA ALAN => Member, Admin => 
app.MapControllerRoute(name: "area", pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(name: "default", pattern: "{Controller=Account}/{Action=Login}/{id?}");

app.Run();
