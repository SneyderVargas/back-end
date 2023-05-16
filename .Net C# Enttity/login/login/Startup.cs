using login.Data;
using login.Data.Entities;
using login.Infrastructure.Services.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace login
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers ();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            services.AddDbContext<DbDefaultContext>();
            var builder = services.AddIdentityCore<UserEntity>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            //Se agrega la instancia dinámica mente al iniciar el programa, usando la técnica de Dependency Injection
            identityBuilder.AddRoles<RoleEntity>();
            identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<UserEntity, RoleEntity>>();
            identityBuilder.AddEntityFrameworkStores<DbDefaultContext>();
            identityBuilder.AddSignInManager<SignInManager<UserEntity>>();//el administrador de LOGIN de accesos va a venir de la clase  (SignInManager) y va a tomar los datos desde la clase  (Usuario)  que viene de dominio.
            services.TryAddSingleton<ISystemClock, SystemClock>();

            //JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));

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
        }
    }
}
