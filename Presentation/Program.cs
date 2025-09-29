using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Service.Interfaces;
using Service.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.WriteIndented = true;
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("LocalDb") ?? throw new NullReferenceException("Connection string is null");
builder.Services.AddDbContext<SqliteDataContext>(opt =>
    opt.UseSqlite(connectionString));

builder.Services.AddIdentity<UserEntity, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<SqliteDataContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAccountService, AccountService>();



var app = builder.Build();
app.MapOpenApi();
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.MapScalarApiReference("/api/docs");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
