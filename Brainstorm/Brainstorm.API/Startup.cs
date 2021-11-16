using System.Text;
using Brainstorm.Business.AppVersions.Handlers;
using Brainstorm.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Brainstorm.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(opts => opts.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                }));

            services.AddMediatR(typeof(GetVersionQueryHandler));
            services.AddDbContext<BrainstormContext>(opts =>
                opts.UseNpgsql(Configuration.GetConnectionString("SqlConnection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my very long secret key which should be longer than 128 bits, you idiot."))
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}