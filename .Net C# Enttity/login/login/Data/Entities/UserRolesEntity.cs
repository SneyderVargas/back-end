using Microsoft.EntityFrameworkCore;

namespace login.Data.Entities
{
    public class UserRolesEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Estado { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserRolesEntity>();

            entity.ToTable("aspnetuserroles");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                 .IsRequired(true);

            entity.Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .IsRequired(true);

            entity.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(500)
                .IsRequired(true);

            entity.Property(x => x.Estado)
            .HasColumnName("Estado")
            .IsRequired(true);
        }
    }
}
