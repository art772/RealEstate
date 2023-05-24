using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using RealEstate.Application;
using RealEstate.Application.Users.RegisterUser.Command;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure;
using RealEstate.Persistance;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddApplication();
builder.Services.AddInfrasructure(builder.Configuration);
builder.Services.AddPersistance(builder.Configuration);

/*
 * Add Jwt
 */

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(o =>
//    {
//        o.RequireHttpsMetadata = false;
//        o.SaveToken = false;
//        o.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ClockSkew = TimeSpan.Zero,

//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//        };
//    });

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(o =>
//    {
//        o.RequireHttpsMetadata = false;
//        o.SaveToken = false;
//        o.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ClockSkew = TimeSpan.Zero,

//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//        };
//    });

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(o =>
//    {
//        o.RequireHttpsMetadata = false;
//        o.SaveToken = false;
//        o.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ClockSkew = TimeSpan.Zero,

//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//        };
//    });


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await UserDbContextSeed.SeedUserRolesAsync(roleManager);
    }
    catch (Exception)
    {
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
