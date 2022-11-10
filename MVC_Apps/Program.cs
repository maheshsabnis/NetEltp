using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using Microsoft.EntityFrameworkCore;
using MVC_Apps.CustomFilters;
using NuGet.Protocol.Plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<eShoppingCodiContext>(opt => 
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
builder.Services.AddScoped<IDbRepository<Category, int>,CategoryRepository>();
builder.Services.AddScoped<IDbRepository<Product, int>, ProductRepository>();
// Accept the Request for MVC and API Controllers
// For MVC Controllers this hels to Locate View to execute
builder.Services.AddControllersWithViews(options => 
{
    // Global REgistration of Action Filter
    options.Filters.Add(typeof(CustomLogRequestAttribute));
    // REgister the Exception Filter
    options.Filters.Add(typeof(AppExceptionAttribute));
});

// COnfigure The Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
   options.IdleTimeout= TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // SHow Error during Development these are standard Error MEssages
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// MIddleware used to read/write Files on Server for Upload and Download
// By default this is used to read contents of 'wwwroot' folder
app.UseStaticFiles();
// CReate, LOad, and Exeute ROute Table for
// MVC Controller ROuting to execute 
// an Action Mathod of a COntrller class
app.UseRouting();
// USe the Session Middleware SO that, the HTTP Pipeline will use
// SessionId as Well as REad Data STored in Session
app.UseSession();

// USed in Case of Role BAsed Security
app.UseAuthorization();
// Map the Incomming HTTP Request URL to
// COrresponding COntroller and the Action Method from the Contrller
// {controller}/{action}/{id?}
// {controller}: The NAme of the COntroller in URL
// {action}: The Action Method from the Controller mentioned in URL
// {id?}: The Nullable Parameter which is a scalar type variable passed to Action MEthod
// e.g.
// http://MyServer/MyApp/MyController/MyAction
// {controller}---> MyController
// {action}---> MyAction

// THe DEfault mentioned here is
// {controller} is Home
// {action} is Idnex
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
