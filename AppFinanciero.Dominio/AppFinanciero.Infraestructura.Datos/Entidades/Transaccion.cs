namespace AppFinanciero.Infraestructura.Datos
{
    public class Transaccion
    {

        public int IdTransaccion { get; set; }
        public int IdTipoTransaccion { get; set; }
        public double numSaldo { get; set; }
        public int IdProductoOrigen { get; set; }
        public int IdProductoDestino { get; set; }

        public TipoTransaccion? TipoTransaccion { get; set; }
        //public Producto? Producto { get; set; }

    }
}