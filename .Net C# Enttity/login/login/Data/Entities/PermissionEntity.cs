using Microsoft.EntityFrameworkCore;

namespace login.Data.Entities
{
    public class PermissionEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int Fk_form { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<PermissionEntity>();

            entity.ToTable("aspnetpermission");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .IsRequired(true);

            entity.Property(x => x.Code)
            .HasColumnName("code")
            .HasMaxLength(20)
            .IsRequired(true);

            entity.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired(true);

            entity.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired(true);

            entity.Property(x => x.Category)
            .HasColumnName("permissioncategoryId")
            .IsRequired(true);

            entity.Property(x => x.Fk_form)
                .HasColumnName("Fk_form")
            .IsRequired(true);
        }
    }
}
