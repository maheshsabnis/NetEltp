using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using Microsoft.EntityFrameworkCore;
using MVC_Apps.CustomFilters;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Identity;
using MVC_Apps.Data;
using MVC_Apps.GlobalApps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<eShoppingCodiContext>(opt => 
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

// REgister the SecurityCodi in AddDbContext

builder.Services.AddDbContext<SecurityCodi>(options => 
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("SecurityCodiConnection"));
});

// THe Service REgistration in Dependency COntainer for Following classes
// 1. USerManager<IdentityUser>
// 2. SignInManager<IdentityUser>

// AddDefaultIdentity<IdentityUser>() for the USer Based Authentication
// THis also Register the Servce for Executing The Razor Views
// using AddRazorPages() Service method INternaly
// SignIn.RequireConfirmedAccount = true The Email MUST be Verified
// AddEntityFrameworkStores<SecurityCodi>();: Read USers Information using
// EF Core
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<SecurityCodi>();




// THe Service REgistration in Dependency COntainer for Following classes
// 1. USerManager<IdentityUser>
// 2. SignInManager<IdentityUser>
// 3. RoleManager<Identiktyole>

// AddDefaultIdentity<IdentityUser>() for the USer Based Authentication
// SignIn.RequireConfirmedAccount = true The Email MUST be Verified
// AddEntityFrameworkStores<SecurityCodi>();: Read USers Information using
// EF Core
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<SecurityCodi>()
    .AddDefaultUI(); // Manage the DEfault Rediret


// Define an Authorization Service to Add Policy for ROles to access the 
// application
//                              AuthorizationOptions
builder.Services.AddAuthorization(options => 
{
                                    // AuthorizationPolicyBuider
    options.AddPolicy("ReadPolicy", policy => 
    {
        policy.RequireRole("Administrator", "Manager", "Clerk", "Operator");
    });
    options.AddPolicy("CreatePolicy", policy =>
    {
        policy.RequireRole("Administrator", "Manager", "Clerk");
    });
    options.AddPolicy("EditPolicy", policy =>
    {
        policy.RequireRole("Administrator", "Manager");
    });
    options.AddPolicy("DeletePolicy", policy =>
    {
        policy.RequireRole("Administrator");
    });
});


builder.Services.AddScoped<IDbRepository<Category, int>,CategoryRepository>();
builder.Services.AddScoped<IDbRepository<Product, int>, ProductRepository>();
// Accept the Request for MVC and API Controllers
// For MVC Controllers this hels to Locate View to execute
builder.Services.AddControllersWithViews(options => 
{
    // Global REgistration of Action Filter
    ///options.Filters.Add(typeof(CustomLogRequestAttribute));
    // REgister the Exception Filter
   // options.Filters.Add(typeof(AppExceptionAttribute));
});

// Register a Service for executing RAzor Views used for Identity
// this is used when AddIdentity<TUser,TRole>() method is used for
// Security
builder.Services.AddRazorPages();

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
// THis is Also used for Making Sure that the NAvidation to IDentity Pages
// is Managed
app.UseStaticFiles();
// CReate, LOad, and Exeute ROute Table for
// MVC Controller ROuting to execute 
// an Action Mathod of a COntrller class
app.UseRouting();
// USe the Session Middleware SO that, the HTTP Pipeline will use
// SessionId as Well as REad Data STored in Session
app.UseSession();
app.UseAuthentication();;

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

// Lets Support request processing for RAzor Views
// (Those are added with the Identity Scaffolded Items)
app.MapRazorPages();

// Call the code for Default Admin Role and User
IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
await GlobalOps.CreateApplicationAdministrator(serviceProvider);

app.Run();
