using Microsoft.EntityFrameworkCore;
using System.Security;

namespace login.Data.Entities
{
    public class PermissionUserEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int State { get; set; }
        public string UserId { get; set; }
        public int PermissionId { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PermissionUserEntity>();
            entity.ToTable("aspnetpermissionuser");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
              .IsRequired(true);

            entity.Property(x => x.CreationDate)
            .HasColumnName("creationDate")
            .IsRequired(true);

            entity.Property(x => x.State)
             .HasColumnName("state")
             .IsRequired(true);

            entity.Property(x => x.UserId)
              .HasColumnName("usersId")
              .HasMaxLength(129)
              .IsRequired(true);

            entity.Property(x => x.PermissionId)
            .HasColumnName("permissionId")
            .IsRequired(true);
        }
    }
}
