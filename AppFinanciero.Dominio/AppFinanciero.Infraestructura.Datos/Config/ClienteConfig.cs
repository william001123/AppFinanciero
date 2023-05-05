using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppFinanciero.Infraestructura.Datos.Config
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));
            builder.HasKey(c => c.IdCliente);

            builder
                .HasMany<Producto>(producto => producto.Producto)
                .WithOne(cliente => cliente.Cliente)
                .HasForeignKey(c => c.IdCliente);   
        }
    }
}
