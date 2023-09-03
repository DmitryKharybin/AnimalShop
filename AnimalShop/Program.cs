using AnimalShop.Data;
using AnimalShop.Repositories;
using AnimalShop.Services;
using ClientService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IApiAccess,ApiAccess>();
//Authentication dataBase registration
builder.Services.AddDbContext<AuthenticationContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Authentication")));

//Identity Configure
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
}
    ).AddEntityFrameworkStores<AuthenticationContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddSingleton<IFileUpload, FileUpload>();

//logger configuration
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build())
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();


//If project in production then do this:
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/ErrorDisplay");
}


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Shop}/{action=MainMenu}");


//Authentication DataBase
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}






app.Run();
