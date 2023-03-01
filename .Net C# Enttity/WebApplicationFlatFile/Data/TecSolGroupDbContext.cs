using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Reflection.Emit;
using AccountControl.Data.Entities;
using AccountControll.Data.Entities;

namespace AccountControl.Data
{
    public class TecSolGroupDbContext: IdentityDbContext<UserEntity, RoleEntity, string>
    {
        private string _connectionString;
        public TecSolGroupDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserEntity.OnModelCreating(modelBuilder);
            RoleEntity.OnModelCreating(modelBuilder);
            AdmEmployeeEntity.OnModelCreating(modelBuilder);
            AdmEmailEntity.OnModelCreating(modelBuilder);
            UserCompanyEntity.OnModelCreating(modelBuilder);
            AdmUsersEntity.OnModelCreating(modelBuilder);
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(GetConnection());
        }
        public DbSet<AdmEmployeeEntity> AdmEmployeeEntities { get; set; }
        public DbSet<AdmEmailEntity> AdmEmailEntities { get; set; }
        public DbSet<UserCompanyEntity> userCompanyEntities { get; set; }
        public DbSet<AdmUsersEntity> admUsersEntities { get; set; }

    }
}
