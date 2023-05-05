using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class TipoTransaccionConfig : IEntityTypeConfiguration<TipoTransaccion>
    {
        public void Configure(EntityTypeBuilder<TipoTransaccion> builder)
        {
            builder.ToTable(nameof(TipoTransaccion));
            builder.HasKey(c => c.IdTipoTransaccion);

            builder
                .HasMany<Transaccion>(producto => producto.Transaccions)
                .WithOne(oItem => oItem.TipoTransaccion)
                .HasForeignKey(c => c.IdTipoTransaccion);
        }
    }
}
