using AccountControl.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountControll.Data.Entities
{
    public class AdmTenancysEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SudDominio { get; set; }
        public int ActiveRegistre { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AdmTenancysEntity>();
            entity.ToTable("tenancys");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .IsRequired(true);
            entity.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(x => x.SudDominio)
                .IsRequired(true)
                .HasMaxLength(200)
                .HasColumnName("sudDominio");
            entity.Property(x => x.ActiveRegistre)
                .HasDefaultValue(1);

        }
    }
}
