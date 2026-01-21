using AutoMapper;
using Ecommerce.Api.DistributedCaching;
using Ecommerce.Application.IRepository;
using Ecommerce.Application.Repository;
using Ecommerce.Domain.Models;
using Ecommerce.Infrastructure.Repositories;
using EcommerceSystem.Api.Extensions;
using EcommerceSystem.Api.Middlewares;
using EcommerceSystem.Application.DTOS;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;
using EcommerceSystem.Infrastructure.Services;
using ECommerceSystem.Security.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

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

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ECommerceSystemDbContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            ),

            ClockSkew = TimeSpan.Zero 
        };

        
        
        
    });


builder.Services.AddStackExchangeRedisCache(delegate (RedisCacheOptions options)
{
    options.Configuration = "localhost:6379";
});
builder.Services.AddMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

builder.Services.ConfigureCors();

//Logging  
builder.Host.UseSerilog();
builder.Services.AddAuthorization();

//Authorization Add Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManageProducts", policy =>
        policy.RequireRole(AppRoles.Admin, AppRoles.SuperAdmin));

    options.AddPolicy("SuperAdminOnly", policy =>
        policy.RequireRole(AppRoles.SuperAdmin));
});


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


app.UseAuthentication();
app.UseAuthorization();

app.UseSerilogRequestLogging();
app.MapControllers();

app.Run();
