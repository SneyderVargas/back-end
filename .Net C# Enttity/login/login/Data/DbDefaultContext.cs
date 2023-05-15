using login.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace login.Data
{
    public class DbDefaultContext : IdentityDbContext<UserEntity, RoleEntity, string>
    {
        private string _connectionString;

        public DbDefaultContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //UserEntity.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(GetConnection());
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        //public DbSet<ParameterEntity> Parameters { get; set; }
    }
}
