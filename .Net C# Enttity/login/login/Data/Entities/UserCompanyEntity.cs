using Microsoft.EntityFrameworkCore;

namespace login.Data.Entities
{
    public class UserCompanyEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool estado { get; set; }
        public int CompanyId { get; set; }
        public string USER_SYSTEM { get; set; }



        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserCompanyEntity>();

            entity.ToTable("aspnetusercompany");

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .IsRequired(true);


            entity.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(500)
                .IsRequired(true);

            entity.Property(x => x.estado)
                .HasColumnName("estado")
                .IsRequired(true)
                .HasDefaultValue(true);

            entity.Property(x => x.CompanyId)
                .HasColumnName("CompanyId")
                .IsRequired(true);

            entity.Property(x => x.USER_SYSTEM)
                .HasColumnName("USER_SYSTEM")
                .HasMaxLength(500)
                .IsRequired(true);


        }
    }
}
