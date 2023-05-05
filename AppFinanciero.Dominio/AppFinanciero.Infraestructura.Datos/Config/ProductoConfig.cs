using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable(nameof(Producto));
            builder.HasKey(c => c.IdProducto);

            //builder
            //    .HasOne<Cliente>(cliente => cliente.Cliente)
            //    .WithMany(producto => producto.Producto)
            //    .HasForeignKey(c => c.IdProducto);

            //builder
            //    .HasMany<Transaccion>(cliente => cliente.Transaccion)
            //    .WithOne(producto => producto.Producto)
            //    .HasForeignKey(c => c.idp);
        }
    }
}
