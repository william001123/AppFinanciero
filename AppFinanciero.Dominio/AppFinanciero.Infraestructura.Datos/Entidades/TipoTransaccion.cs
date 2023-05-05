namespace AppFinanciero.Infraestructura.Datos
{
    public class TipoTransaccion
    {

        public int IdTipoTransaccion { get; set; }
        public string? strNombre { get; set; }

        public List<Transaccion> Transaccions { get; set; }

    }
}