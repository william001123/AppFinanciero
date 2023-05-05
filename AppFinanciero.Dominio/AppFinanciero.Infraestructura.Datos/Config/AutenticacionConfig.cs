using AppFinanciero.Infraestructura.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class AutenticacionConfig : IEntityTypeConfiguration<Autenticacion>
    {
        public void Configure(EntityTypeBuilder<Autenticacion> builder)
        {
            builder.ToTable(nameof(Autenticacion));
            builder.HasKey(c => c.Usuario);
            builder.HasKey(c => c.Contrasena);
        }
    }
}
