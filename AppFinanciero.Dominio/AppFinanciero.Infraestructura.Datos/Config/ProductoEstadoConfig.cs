using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class ProductoEstadoConfig : IEntityTypeConfiguration<ProductoEstado>
    {
        public void Configure(EntityTypeBuilder<ProductoEstado> builder)
        {
            builder.ToTable(nameof(ProductoEstado));
            builder.HasKey(c => c.IdProductoEstado);


            builder
                .HasMany<Producto>(producto => producto.Productos)
                .WithOne(oItem => oItem.ProductoEstado)
                .HasForeignKey(c => c.intEstado);
        }
    }
}
