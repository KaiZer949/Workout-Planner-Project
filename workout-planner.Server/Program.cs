using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using workout_planner.Server.Database;
using workout_planner.Server.JWT;

var builder = WebApplication.CreateBuilder(args);

// For react api to properly fetch data 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .WithOrigins("http://localhost:5173") // React dev server
            .AllowAnyMethod()
            .AllowAnyHeader());
});


//ConnectionString

var connectionString = builder.Configuration.GetConnectionString("DbConnect");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddConnections();


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(jwtOptions =>
//    {
//        jwtOptions.TokenValidationParameters = new TokenValidationParameters
//        {

//            RequireExpirationTime = true,
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["jwt:issuer"],
//            ValidAudience = builder.Configuration["jwt:audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(
//                    System.Text.Encoding.UTF8.GetBytes(
//                        builder.Configuration["jwt:secret_key"]))
//        };

//    });

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString)); //Scoped As well
builder.Services.AddScoped<JWTService>();


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



app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
