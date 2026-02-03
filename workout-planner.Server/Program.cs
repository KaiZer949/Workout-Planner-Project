using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using workout_planner.Server.Database;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString

var connectionString = builder.Configuration.GetConnectionString("DbConnect");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddConnections();


builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString)); //Scoped As well


var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
