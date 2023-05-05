using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class TransaccionConfig : IEntityTypeConfiguration<Transaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.ToTable(nameof(Transaccion));
            builder.HasKey(c => c.IdTransaccion);

            //builder
            //    .HasOne<Producto>(producto => producto.Producto)
            //    .WithMany(transaccion => transaccion.Transaccion);
        }
    }
}
