using Microsoft.AspNetCore.Identity;
using SmartStore.DataAccess.Contexts;
using SmartStore.DataAccess.Extensions;
using SmartStore.Models.Entities;
using SmartStore.Services.Extensions;
using SmartStore.WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDataAccessDependencies(builder.Configuration);
builder.Services.AddServicesDependencies();


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

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(_ => { });

app.UseAuthorization();

app.MapControllers();

app.Run();
