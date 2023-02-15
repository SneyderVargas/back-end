﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Reflection.Emit;
using WebApplicationFlatFile.Data.Entities;

namespace WebApplicationFlatFile.Data
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
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(GetConnection());
        }

    }
}