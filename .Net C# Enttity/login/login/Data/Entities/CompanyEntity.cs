using Microsoft.EntityFrameworkCore;

namespace login.Data.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string NumDocument { get; set; }
        public string UserCreated { get; set; }
        public string UserUpdated { get; set; }
        public bool Active { get; set; }
        public string FACTURA_IMG { get; set; }



        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CompanyEntity>();

            entity.ToTable("aspnetcompany");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .IsRequired(true);

            entity.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired(true);

            entity.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsRequired(true);

            entity.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(190)
                .IsRequired(true);

            entity.Property(x => x.NumDocument)
                .HasColumnName("NumDocument")
                .HasMaxLength(100)
                .IsRequired(true);



            entity.Property(x => x.UserCreated)
                .HasColumnName("UserCreated")
                .HasMaxLength(128)
                .IsRequired(true);

            entity.Property(x => x.UserUpdated)
                .HasColumnName("UserUpdated")
                .HasMaxLength(128)
                .IsRequired(true);


            entity.Property(x => x.Active)
                .HasColumnName("Active")
                .IsRequired(true)
                .HasDefaultValue(true);

            entity.Property(x => x.FACTURA_IMG)
               .HasColumnName("FACTURA_IMG")
               .HasMaxLength(255);

        }
    }
}
