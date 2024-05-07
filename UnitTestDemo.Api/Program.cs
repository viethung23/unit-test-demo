using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnitTestDemo.Api.Data;
using UnitTestDemo.Api.Middelwares;
using UnitTestDemo.Api.Repositories;
using UnitTestDemo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// sử dụng InMemoryDatabase 
builder.Services.AddDbContext<TestDbContext>(option =>
{
    option.UseInMemoryDatabase("TestDB");
});

// Đăng kí service 
builder.Services.AddScoped<IProductService, ProductService>();
// Đăng kí repo 
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Đăng kí Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// đăng kí middleware
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

// Seeding database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TestDbContext>();
    DataSeeder.SeedCountries(context);  // Make sure this method is correctly accessible
}

app.Run();
