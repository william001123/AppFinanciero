using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;
using System.Collections.Generic;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class TipoProductoMapper
    {
        public static TipoProductoDto Map(this TipoProductoDominio model)
        {
            return new TipoProductoDto()
            {
                strNombre = model.strNombre,                
            };
        }

        public static List<TipoProductoDto> Map(this List<TipoProductoDominio> model)
        {
            List<TipoProductoDto> tipoProductoDtos = new List<TipoProductoDto>();

            foreach (TipoProductoDominio modelItem in model)
            {
                tipoProductoDtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto() { strNombre = modelItem.strNombre});
            }

            return tipoProductoDtos;
        }

        public static TipoProductoDominio Map(this TipoProductoDto DTO)
        {
            return new TipoProductoDominio()
            {
                IdTipoProducto = DTO.IdTipoProducto,
                strNombre = DTO.strNombre                
            };
        }

    }
}