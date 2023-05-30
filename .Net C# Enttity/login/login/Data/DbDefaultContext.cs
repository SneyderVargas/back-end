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
            PermissionEntity.OnModelCreating(modelBuilder);
            UserCompanyEntity.OnModelCreating(modelBuilder);
            CompanyEntity.OnModelCreating(modelBuilder);
            UserRolesEntity.OnModelCreating(modelBuilder);
            PermissionUserEntity.OnModelCreating(modelBuilder);
            PermissionUserEntity.OnModelCreating(modelBuilder);
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
        public DbSet<PermissionEntity> permissionEntities { get; set; }
        public DbSet<UserCompanyEntity> userCompanyEntities { get; set; }
        public DbSet<CompanyEntity> companyEntities { get; set; }
        public DbSet<UserRolesEntity> userRolesEntities { get; set; }
        public DbSet<PermissionUserEntity> permissionUserEntities { get; set; }
    }
}
