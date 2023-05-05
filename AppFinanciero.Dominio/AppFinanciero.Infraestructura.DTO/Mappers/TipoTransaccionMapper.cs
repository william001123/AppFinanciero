using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class TipoTransaccionMapper
    {
        public static TipoTransaccionDto Map(this TipoTransaccionDominio model)
        {
            return new TipoTransaccionDto()
            {
                IdTipoTransaccion = model.IdTipoTransaccion,
                strNombre = model.strNombre,                
            };
        }

        public static List<TipoTransaccionDto> Map(this List<TipoTransaccionDominio> model)
        {
            List<TipoTransaccionDto> Dtos = new List<TipoTransaccionDto>();

            foreach (TipoTransaccionDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static TipoTransaccionDominio Map(this TipoTransaccionDto DTO)
        {
            return new TipoTransaccionDominio()
            {
                IdTipoTransaccion = DTO.IdTipoTransaccion,
                strNombre = DTO.strNombre                
            };
        }

    }
}