using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;
using System.Collections.Generic;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class ProductoEstadoMapper
    {
        public static ProductoEstadoDto Map(this ProductoEstadoDominio model)
        {
            return new ProductoEstadoDto()
            {
                IdProductoEstado = model.IdProductoEstado,
                strNombre = model.strNombre,                
            };
        }

        public static List<ProductoEstadoDto> Map(this List<ProductoEstadoDominio> model)
        {
            List<ProductoEstadoDto> Dtos = new List<ProductoEstadoDto>();

            foreach (ProductoEstadoDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static ProductoEstadoDominio Map(this ProductoEstadoDto DTO)
        {
            return new ProductoEstadoDominio()
            {
                IdProductoEstado = DTO.IdProductoEstado,
                strNombre = DTO.strNombre                
            };
        }

    }
}