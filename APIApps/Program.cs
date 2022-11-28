using APIApps.CustomOps.CustomMiddlewares;
using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the eShoppingCodeContext in DI COntainer
// Also Provide the ConectionString fpr SQL Server

builder.Services.AddDbContext<eShoppingCodiContext>(options => 
{
    // pass the Connection String
    // using the builder.Configuration.GetConnectionString()
    // this will read the "ConnectionString" section of appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});


builder.Services.AddDbContext<SecurityCodiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecureConnection"));
});

// REgister the Custom Service classes in DI Container

builder.Services.AddScoped<IDbAccessService<Category,int>, CategoryDataAccessService>();
builder.Services.AddScoped<IDbAccessService<Product,int>,ProductDataAccessService>();


// REgister the HTTP Pipeline for API COntrollers
// THis will loo for API Controllers instance and execute it
// AddJsonOptions() an additional Service to manage the Response Formatting
builder.Services.AddControllers().AddJsonOptions(options => {
    // ReSet the JSON Serialization to the format for
    // Property Naming as per provided in ENtity class
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    
});

// COnfigure the API for Cross-Origin-Resource-SHaring Service
builder.Services.AddCors(options => 

{
    options.AddPolicy("CORS",policy => 
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
// The Service for Memory Cache
builder.Services.AddMemoryCache();

// USe the ASP.NET Core Identity for UserManager<IdentityUser> and 
// SIgnInManager<IdentityRole>()
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SecurityCodiDbContext>();


builder.Services.AddScoped<SecurityService>();

// Inform to the Host that the Current API is using Token BAsed AUthorication 

// Logic for Token Verification
byte[] secretKey = Convert.FromBase64String(builder.Configuration["JWTCoreSettings:SecretKey"]);


builder.Services.AddAuthentication(x =>
{
    // set the Scheme for HEader Value Verification
    // HTTP Request Header MUST use the Authorzation:'Bearer <TOKEN-VALUE>'
    // in Request
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Validate the Token
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Signeture Verification
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Provide CORS Policy to HTTP Pipeline using the UseCors() Middleware
app.UseCors("CORS");

app.UseAuthentication();    
app.UseAuthorization();

// USe the Custom MIddleware
app.UseAppExceptionHandler();

// Map the API Controller to the Incomming Request
app.MapControllers();

app.Run();
