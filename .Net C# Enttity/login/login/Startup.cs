using AutoMapper;
using login.Data;
using login.Data.Entities;
using login.Domain.Helpers;
using login.Infrastructure.Services.Security;
using login.Middleware;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta token"));

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
            services.AddScoped<IAccountService, AccountService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Servicios para control de login",
                    Version = "v1"
                });
                c.CustomSchemaIds(c => c.FullName);
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "nosniff");
                await next();
            });

            // ...
            app.UseCors("AllowCorsPolicy");
            // ...
            app.UseMiddleware<ErrorMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage(); // se retira  por que usamos nuestra propia Middleware (ManejadorErrorMiddleware)
            }

            //app.UseHttpsRedirection();
            app.UseAuthentication(); //Se le indica a esta aplicación que usara autenticación, en este caso JWT.

            app.UseRouting();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cursos Online v1");
            });

            System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
