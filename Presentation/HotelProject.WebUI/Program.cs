using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DtoLayer.Dtos.ServiceDtos;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.ApiService;
using HotelProject.WebUI.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IApiSettings, ApiSettings>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMvc(cfg =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    cfg.Filters.Add(new AuthorizeFilter(policy));

});
builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.Cookie.HttpOnly = true;
    cfg.LoginPath = "/Admin/Login/Index";
    cfg.AccessDeniedPath = "/Admin/Login/Index";
    cfg.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseStatusCodePagesWithReExecute("/ErrorPage/err404", "?code={0}");
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
