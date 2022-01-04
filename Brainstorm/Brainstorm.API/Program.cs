using System.Text;
using Brainstorm.Business.AppVersions.Handlers;
using Brainstorm.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.
builder.Services.AddMediatR(typeof(GetVersionQueryHandler));
builder.Services.AddDbContext<BrainstormContext>(opts =>
    opts.UseNpgsql(config.GetConnectionString("SqlConnection")));
builder.Services.AddControllers();
builder.Services.AddCors(opts => opts.AddDefaultPolicy(
    corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    }));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "brainstorm-inc",
            ValidAudience = "brainstorm-inc",
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    "this is my very long secret key which should be longer than 128 bits, you idiot."))
        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();