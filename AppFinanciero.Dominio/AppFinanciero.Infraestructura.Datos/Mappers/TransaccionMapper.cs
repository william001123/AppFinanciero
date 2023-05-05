using AppFinanciero.Dominio.Modelos;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class TransaccionMapper
    {
        public static Transaccion Map(this TransaccionDominio model)
        {
            return new Transaccion()
            {
                IdTransaccion = model.IdTransaccion,
                IdTipoTransaccion = model.IdTipoTransaccion,
                numSaldo = model.numSaldo,
                IdProductoOrigen = model.IdProductoOrigen,
                IdProductoDestino = model.IdProductoDestino
            };
        }

        public static List<Transaccion> Map(this List<TransaccionDominio> model)
        {
            List<Transaccion> Dtos = new List<Transaccion>();

            foreach (TransaccionDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static List<TransaccionDominio> Map(this List<Transaccion> model)
        {
            List<TransaccionDominio> Dtos = new List<TransaccionDominio>();

            foreach (Transaccion modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static TransaccionDominio Map(this Transaccion DTO)
        {
            return new TransaccionDominio()
            {
                IdTransaccion = DTO.IdTransaccion,
                IdTipoTransaccion = DTO.IdTipoTransaccion,
                numSaldo = DTO.numSaldo,
                IdProductoOrigen = DTO.IdProductoOrigen,
                IdProductoDestino = DTO.IdProductoDestino
            };
        }

    }
}