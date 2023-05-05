namespace AppFinanciero.Infraestructura.Datos
{
    public class TipoProducto
    {

        public int IdTipoProducto { get; set; }
        public string? strNombre { get; set; }

        public List<Producto> Productos { get; set; }
    }
}