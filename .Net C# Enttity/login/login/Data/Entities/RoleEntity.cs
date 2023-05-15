using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace login.Data.Entities
{
    public class RoleEntity : IdentityRole
    {
        public RoleEntity() : base()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public override string Id { get; set; }
        public RoleEntity(string Name) : this()
        {
            base.Name = Name;
        }

        public string InternalCode { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<RoleEntity>().ToTable("aspnetroles");
            modelBuilder.Entity<RoleEntity>(entity => entity.Property(p => p.Id).HasMaxLength(128));
            modelBuilder.Entity<RoleEntity>(entity => entity.Property(p => p.ConcurrencyStamp));
            modelBuilder.Entity<RoleEntity>(entity => entity.Property(p => p.InternalCode).HasColumnName("internalCode").HasMaxLength(20));
            modelBuilder.Entity<RoleEntity>(entity => entity.Property(p => p.Name).HasMaxLength(256));
            modelBuilder.Entity<RoleEntity>(entity => entity.Property(p => p.NormalizedName).HasMaxLength(128));
        }
    }
}
