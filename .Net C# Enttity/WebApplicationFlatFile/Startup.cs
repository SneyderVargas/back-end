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
        }
    }
}
