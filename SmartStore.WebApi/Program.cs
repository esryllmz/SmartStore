using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SmartStore.Core.Tokens.Configurations;
using SmartStore.DataAccess.Contexts;
using SmartStore.DataAccess.Extensions;
using SmartStore.Models.Entities;
using SmartStore.Services.Extensions;
using SmartStore.WebApi.Middlewares;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDataAccessDependencies(builder.Configuration);
builder.Services.AddServicesDependencies();


builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("TokenOption"));

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.AllowedUserNameCharacters =
              "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 6;

    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<BaseDbContext>();


var tokenOption = builder.Configuration.GetSection("TokenOption").Get<TokenOption>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience[0],
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOption.SecurityKey),
        RoleClaimType = ClaimTypes.Role
    };
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
