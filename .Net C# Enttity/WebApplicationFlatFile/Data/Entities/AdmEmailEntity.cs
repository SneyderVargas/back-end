using Microsoft.EntityFrameworkCore;

namespace AccountControl.Data.Entities
{
    public class AdmEmailEntity
    {
        public long id { get; set; }
        public int idForm { get; set; }
        public string idUser { get; set; }
        //public string email { get; set; }
        public string process { get; set; }
        public bool status { get; set; }
        public int order { get; set; }
        public DateTimeOffset dateRegister { get; set; }
        public string login { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AdmEmailEntity>();
            entity.ToTable("adm_correos");
            entity.HasKey(x => x.id);

            entity.Property(x => x.id)
                .IsRequired(true);

            entity.Property(x => x.idForm)
                .IsRequired(true);

            entity.Property(x => x.idUser)
                .IsRequired(true);

            //entity.Property(x => x.email)
            //    .HasColumnName("email")
            //    .HasMaxLength(100)
            //    .IsRequired(true);


            entity.Property(x => x.process)
                .HasColumnName("proceso")
                .HasMaxLength(100)
                .IsRequired(true);


            entity.Property(x => x.status)
                .HasColumnName("estado")
                .IsRequired(true)
                .HasDefaultValue(true);

            entity.Property(x => x.order)
                 .HasColumnName("orden")
                 .IsRequired(true);

            entity.Property(x => x.dateRegister)
                .HasColumnName("fec_registro")
                .IsRequired(true);

            entity.Property(x => x.login)
                .HasColumnName("login")
                .HasMaxLength(129)
                .IsRequired(true);
        }
    }
}
