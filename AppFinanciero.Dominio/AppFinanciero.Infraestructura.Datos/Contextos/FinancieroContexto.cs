using AppFinanciero.Infraestructura.Datos.Config;
using AppFinanciero.Infraestructura.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppFinanciero.Infraestructura.Datos.Contextos
{
    public class FinancieroContexto: DbContext
    {
        //Se agregan los modelos del dominio

        public DbSet<Autenticacion> Autenticacion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoEstado> ProductoEstado { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<TipoTransaccion> TipoTransaccion { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }

        public FinancieroContexto()
        {
        }

        public FinancieroContexto(DbContextOptions<FinancieroContexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            //IConfigurationRoot root = builder.Build();

            //optionsBuilder.UseSqlServer(root["ConnectionStrings:Financiero"]);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6GEM4G9;Initial Catalog=dbFinanciero;Integrated Security=true;Trust Server Certificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AutenticacionConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new ProductoEstadoConfig());
            modelBuilder.ApplyConfiguration(new TipoProductoConfig());
            modelBuilder.ApplyConfiguration(new TipoTransaccionConfig());
            modelBuilder.ApplyConfiguration(new TransaccionConfig());

        }
    }
}
