using Microsoft.EntityFrameworkCore;
using si730pc2u20201b338.API.Mapper;
using si730pc2u20201b338.Domain;
using si730pc2u20201b338.Domain.Infrastructure;
using si730pc2u20201b338.Infrastructure.Context;
using si730pc2u20201b338.Infrastructure.Infrastructure;
using si730pc2u20201b338.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IDestinationDomain, DestinationDomain>();
builder.Services.AddScoped<IDestinationInfrastructure, DestinationInfrastructure>();

//MySql Connection
var connectionString = builder.Configuration.GetConnectionString("WebAppConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<ProjectContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

//Mapper
builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel)
);

//Build
var app = builder.Build();

// Create database if not exists
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<ProjectContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();