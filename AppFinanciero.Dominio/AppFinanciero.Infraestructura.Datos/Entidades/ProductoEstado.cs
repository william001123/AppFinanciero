namespace AppFinanciero.Infraestructura.Datos
{
    public class ProductoEstado
    {

        public int IdProductoEstado { get; set; }
        public string? strNombre { get; set; }

        public List<Producto> Productos { get; set; }

    }
}