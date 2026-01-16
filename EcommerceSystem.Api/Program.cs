using AutoMapper;
using Ecommerce.Api.DistributedCaching;
using Ecommerce.Application.IRepository;
using Ecommerce.Application.Repository;
using Ecommerce.Infrastructure.Repositories;
using EcommerceSystem.Api.Extensions;
using EcommerceSystem.Api.Middlewares;
using EcommerceSystem.Application.DTOS;
using EcommerceSystem.Infrastructure.Data;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configure the DbContext with the connection string
builder.Services.AddDbContext<ECommerceSystemDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUniteOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageReposioty>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddAutoMapper(delegate (IMapperConfigurationExpression cfg)
{
    cfg.AddProfile<MappingProfile>();
});
builder.Services.AddStackExchangeRedisCache(delegate (RedisCacheOptions options)
{
    options.Configuration = "localhost:6379";
});
builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();

//Logging  
builder.Host.UseSerilog();

 

Log.Logger=new LoggerConfiguration().WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var app = builder.Build();





// Enable Swagger (usually only in Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseGlobalExceptionHandling();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseSerilogRequestLogging();
app.MapControllers();

app.Run();
