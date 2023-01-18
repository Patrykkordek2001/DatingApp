using DatingApp.Data;
using Microsoft.EntityFrameworkCore;
using DatingApp.Interfaces;
using DatingApp.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DatingApp.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdenityServicers(builder.Configuration);


var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:4200"));


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
