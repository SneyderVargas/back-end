using login.Data;

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
        }
    }
}
