using AnimalApi.Data;
using AnimalApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(j =>
j.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddDbContext<AnimalContext>(option =>
option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);
var app = builder.Build();
app.UseRouting();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.Run();
