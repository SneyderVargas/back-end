using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using System.Text;
using AccountControl.Data;
using AccountControl.Data.Entities;
using AccountControl.Helpers;
using AccountControl.Services.Email;
using AccountControl.Services.Security;
using AccountControll.Services.Security;

namespace AccountControl
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

            //services.AddDevExpressControls();
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
            services.AddScoped<ISendEmailByFormService, SendEmailByFormService>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<ITenancysServices, TenancysServices>();

            //services.AddScoped<IJwtGenerador, JwtGenerador>();
            //services.AddScoped<IEmailService, MailKitEmailService>();
            //services.AddScoped<ISendingMailByFormService, SendingMailByFormService>();
            //services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IPermissionService, PermissionService>();
            //services.AddScoped<IAssetsParametersService, AssetsParametersService>();
            //services.AddScoped<ICompanyService, CompanyService>();
            ////Obtener usuario de sesion
            //services.AddScoped<IUsuarioSesion, UsuarioSesion>();
            //services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();

            ////Controller de SURGAS
            //// services.AddScoped<IFacturacionService, FacturacionService>();
            //// services.AddScoped<IWS_FacturacionService, WS_FacturacionService>();


            ////Controller Asobancaria
            //services.AddScoped<IAsobancariaService, AsobancariaService>();
            ////services.AddAutoMapper(typeof(UsuarioSesion));

            var config = new MapperConfiguration(mC =>
            {
                mC.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Servicios para Control de TecsolGroup",
                    Version = "v1",
                });
                c.CustomSchemaIds(c => c.FullName);
            });
            services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));
            // ... INI REPORT
            services
                .AddMvc()
                .AddNewtonsoftJson();

            //services.ConfigureReportingServices(configurator =>
            //{
            //    configurator.ConfigureReportDesigner(designerConfigurator =>
            //    {
            //        designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
            //    });
            //    configurator.ConfigureWebDocumentViewer(viewerConfigurator =>
            //    {
            //        viewerConfigurator.UseCachedReportSourceBuilder();
            //    });
            //    configurator.DisableCheckForCustomControllers();
            //});
            // ... FIN REPORT




            //services.TryAddSingleton<ISystemClock, SystemClock>();

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

            // ...
            app.UseCors("AllowCorsPolicy");
            // ...




            app.UseMiddleware<ManejadorErrorMiddleware>();

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



            // ... INI REPORT
            var reportingLogger = loggerFactory.CreateLogger("DXReporting");
            //DevExpress.XtraReports.Web.ClientControls.LoggerService.Initialize((exception, message) =>
            //{
            //    var logMessage = $"[{DateTime.Now}]: Exception occurred. Message: '{message}'. Exception Details:\r\n{exception}";
            //    reportingLogger.LogError(logMessage);
            //});
            //DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
            //app.UseDevExpressControls();
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
