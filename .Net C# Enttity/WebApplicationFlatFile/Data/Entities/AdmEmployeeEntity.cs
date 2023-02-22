using Microsoft.EntityFrameworkCore;

namespace WebApplicationFlatFile.Data.Entities
{
    public class AdmEmployeeEntity
    {
        public long id { get; set; }
        public string pNombre { get; set; }
        public string sNombre { get; set; }
        public string pApellido { get; set; }
        public string sApellido { get; set; }
        public string nombreCompleto { get; set; }
        public string nit { get; set; }
        public string email { get; set; }
        public long jefe { get; set; }
        public long idCargo { get; set; }
        public DateTimeOffset fecIngreso { get; set; }
        public DateTimeOffset fecNacimiento { get; set; }
        public bool estado { get; set; }
        public int orden { get; set; }
        public DateTimeOffset fecRegistro { get; set; }
        public string login { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AdmEmployeeEntity>();
            entity.ToTable("adm_empleados");
            entity.HasKey(x => x.id);

            entity.Property(x => x.id)
                .IsRequired(true);

            entity.Property(x => x.pNombre)
                .HasColumnName("p_nombre")
                .HasMaxLength(200)
                .IsRequired(true);

            entity.Property(x => x.sNombre)
                .HasColumnName("s_nombre")
                .HasMaxLength(200)
                .IsRequired(true);


            entity.Property(x => x.pApellido)
                .HasColumnName("p_apellido")
                .HasMaxLength(200)
                .IsRequired(true);


            entity.Property(x => x.sApellido)
                .HasColumnName("s_apellido")
                .HasMaxLength(200)
                .IsRequired(true);


            entity.Property(x => x.nombreCompleto)
                .HasColumnName("nombre_completo")
                .HasMaxLength(500)
                .IsRequired(true);


            entity.Property(x => x.nit)
                .HasColumnName("nit")
                .HasMaxLength(50)
                .IsRequired(true);

            entity.Property(x => x.email)
                .HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired(true);

            entity.Property(x => x.jefe)
                .IsRequired(true);

            entity.Property(x => x.idCargo)
                .HasColumnName("fk_cargo")
                .IsRequired(true);

            entity.Property(x => x.fecIngreso)
                  .HasColumnName("fec_ingreso");

            entity.Property(x => x.fecNacimiento)
                    .HasColumnName("fec_nacimiento");

            entity.Property(x => x.estado)
                .HasColumnName("estado")
                .IsRequired(true)
                .HasDefaultValue(true);

            entity.Property(x => x.orden)
             .HasColumnName("orden")
             .IsRequired(true);

            entity.Property(x => x.fecRegistro)
              .HasColumnName("fec_registro")
              .IsRequired(true);

            entity.Property(x => x.login)
             .HasColumnName("login")
             .HasMaxLength(129)
             .IsRequired(true);

        }


    }
}
