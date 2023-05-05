namespace AppFinanciero.Infraestructura.Datos
{
    public class Producto
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
        
        public TipoProducto? TipoProducto { get; set; }
        public ProductoEstado? ProductoEstado { get; set; }
        public Cliente? Cliente { get; set; }
        //public List<Transaccion>? Transaccion { get; set; }

    }

}