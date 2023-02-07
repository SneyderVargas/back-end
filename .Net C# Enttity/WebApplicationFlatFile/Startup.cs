using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Cryptography;

namespace WebApplicationFlatFile
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.TryAddSingleton<ISystemClock, SystemClock>();

            //Service JWT
            //var key = new SymmetricSecurityKey()

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "nosniff");
                await next();
            });
            app.UseCors(
                option =>
                option.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyMethod()
                );
            if (env.IsDevelopment())
            {

            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseSwagger();
        }
    }
}
