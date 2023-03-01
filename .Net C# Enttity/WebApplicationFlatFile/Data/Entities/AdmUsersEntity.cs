using Microsoft.EntityFrameworkCore;

namespace AccountControll.Data.Entities
{
    public class AdmUsersEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string TypeUsers { get; set; }
        public string ? Data {get; set;}
        public DateTime LastLogin { get; set; }
        public int Active { get; set; }
        public DateTime CreateRegisterDate { get; set; }
        public DateTime UpdateRegisterDate { get; set; }
        public int ActiveRegister { get; set; }
        public int Tenancys { get; set; }
        public string ? Steps  { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AdmUsersEntity>();
            entity.ToTable("users");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired(true);
            entity.Property(x => x.Email)
                .HasColumnName("email");
            entity.Property(x => x.Name)
                .HasColumnName("name");
            entity.Property(x => x.Password)
                .HasColumnName("password");
            entity.Property(x => x.TypeUsers)
                .HasColumnName("typeUsers");
            entity.Property(x => x.Data)
                .HasColumnName("data");
            entity.Property(x => x.LastLogin)
                .HasColumnName("lastLogin");
            entity.Property(x => x.Active)
                .HasColumnName(@"active");
            entity.Property(x => x.CreateRegisterDate)
                .HasColumnName("createRegisterDate");
            entity.Property(x => x.ActiveRegister)
                .HasColumnName("activeRegister");
            entity.Property(x => x.Tenancys)
                .HasColumnName("tenancys");
            entity.Property(x => x.Steps)
                .HasColumnName("steps");
        }
    }
}
