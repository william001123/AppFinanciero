using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class TransaccionMapper
    {
        public static TransaccionDto Map(this TransaccionDominio model)
        {
            return new TransaccionDto()
            {
                IdTransaccion = model.IdTransaccion,
                IdTipoTransaccion = model.IdTipoTransaccion,
                numSaldo = model.numSaldo,
                IdProductoOrigen = model.IdProductoOrigen,
                IdProductoDestino = model.IdProductoDestino
            };
        }

        public static List<TransaccionDto> Map(this List<TransaccionDominio> model)
        {
            List<TransaccionDto> Dtos = new List<TransaccionDto>();

            foreach (TransaccionDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static List<TransaccionDominio> Map(this List<TransaccionDto> model)
        {
            List<TransaccionDominio> Dtos = new List<TransaccionDominio>();

            foreach (TransaccionDto modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static TransaccionDominio Map(this TransaccionDto DTO)
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