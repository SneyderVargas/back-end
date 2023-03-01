using Microsoft.EntityFrameworkCore;

namespace AccountControl.Data.Entities
{
    public class UserCompanyEntity
    {
        public int id { get; set; }
        public string idUser { get; set; }
        public bool status { get; set; }
        public int idCompany { get; set; }
        public string USER_SYSTEM { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserCompanyEntity>();
            entity.ToTable("aspnetusercompany");

            entity.HasKey(x => x.id);
            entity.Property(x => x.id)
                .IsRequired(true);


            entity.Property(x => x.idUser)
                .HasColumnName("UserId")
                .HasMaxLength(500)
                .IsRequired(true);

            entity.Property(x => x.status)
                .HasColumnName("estado")
                .IsRequired(true)
                .HasDefaultValue(true);

            entity.Property(x => x.idCompany)
                .HasColumnName("CompanyId")
                .IsRequired(true);

            entity.Property(x => x.USER_SYSTEM)
                .HasColumnName("USER_SYSTEM")
                .HasMaxLength(500)
                .IsRequired(true);
        }
    }
}
