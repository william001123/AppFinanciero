namespace AppFinanciero.Dominio.Modelos
{
    public class TransaccionDominio
    {

        public int IdTransaccion { get; set; }
        public int IdTipoTransaccion { get; set; }
        public double numSaldo { get; set; }
        public int IdProductoOrigen { get; set; }
        public int IdProductoDestino { get; set; }

        public TipoTransaccionDominio? TipoTransaccion { get; set; }
        public ProductoDominio? Producto { get; set; }

    }
}