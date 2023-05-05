using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class TipoProductoConfig : IEntityTypeConfiguration<TipoProducto>
    {
        public void Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            builder.ToTable(nameof(TipoProducto));
            builder.HasKey(c => c.IdTipoProducto);


            builder
                .HasMany<Producto>(producto => producto.Productos)
                .WithOne(oItem => oItem.TipoProducto)
                .HasForeignKey(c => c.IdTipoProducto);
        }
    }
}
