using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using WebApplicationFlatFile.Data;
using WebApplicationFlatFile.Data.Entities;
using WebApplicationFlatFile.Services.Email;
using WebApplicationFlatFile.Services.Security;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCorsPolicy", buider =>
                {
                    buider.AllowAnyOrigin();
                    buider.AllowAnyMethod();
                    buider.AllowAnyHeader();
                });
            });
            services.AddDbContext<TecSolGroupDbContext>();
            var builder = services.AddIdentityCore<UserEntity>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            // Se agref la instalcia dinamicamente al iniciar el proyecto, usando la tecnica de Dependency Injection
            identityBuilder.AddRoles<RoleEntity>();
            identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<UserEntity, RoleEntity>>();
            identityBuilder.AddEntityFrameworkStores<TecSolGroupDbContext>();
            identityBuilder.AddSignInManager<SignInManager<UserEntity>>();//el administrador de LOGIN de accesos va a venir de la clase  (SignInManager) y va a tomar los datos desde la clase  (Usuario)  que viene de dominio.
            services.TryAddSingleton<ISystemClock, SystemClock>();

            //Jwt
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["MyLetterSecret"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                // ValidateAudience = false,  aca se coloca la IP que va a usar el TOKEN
                //ValidateIssuer = false,     aca se coloca la IP a las cuales se le van a enviar el TOKEN
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IEmailService, MailkitEmailService>();
            services.AddScoped<>();
            //services.TryAddSingleton<ISystemClock, SystemClock>();

            //Service JWT
            //var key = new SymmetricSecurityKey()

        }
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        context.Response.Headers.Add("X-Frame-Options", "nosniff");
        //        await next();
        //    });
        //    app.UseCors(
        //        option =>
        //        option.AllowAnyOrigin()
        //        .AllowAnyMethod()
        //        .AllowAnyMethod()
        //        );
        //    if (env.IsDevelopment())
        //    {

        //    }
        //    app.UseAuthentication();
        //    app.UseRouting();
        //    app.UseSwagger();
        //}
    }
}
