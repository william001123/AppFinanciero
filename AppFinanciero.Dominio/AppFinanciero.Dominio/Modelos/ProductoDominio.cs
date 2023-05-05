namespace AppFinanciero.Dominio.Modelos
{
    public class ProductoDominio
    {

        public int IdProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public string? NumeroCuenta { get; set; }
        public int intEstado { get; set; }
        public double numSaldo { get; set; }
        public string? ExentaGMF { get; set; }
        public DateTime dtFechaCreacion { get; set; }
        public DateTime dtFechaModificacion { get; set; }
        public int IdCliente { get; set; }
        
        public TipoProductoDominio? TipoProducto { get; set; }
        public ProductoEstadoDominio? ProductoEstado { get; set; }
        public ClienteDominio? Cliente { get; set; }
        public List<TransaccionDominio>? Transaccion { get; set; }

    }

}