using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;
using System.Reflection;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class ProductoMapper
    {
        public static ProductoDto Map(this ProductoDominio model)
        {
            return new ProductoDto()
            {
                IdProducto = model.IdProducto,
                IdTipoProducto = model.IdTipoProducto,
                NumeroCuenta = model.NumeroCuenta,
                intEstado = model.intEstado,
                numSaldo = model.numSaldo,
                ExentaGMF = model.ExentaGMF,
                IdCliente = model.IdCliente
            };
        }

        public static List<ProductoDto> Map(this List<ProductoDominio> model)
        {
            List<ProductoDto> Dtos = new List<ProductoDto>();

            foreach (ProductoDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
            }

            return Dtos;
        }

        public static ProductoDominio Map(this ProductoDto DTO)
        {
            return new ProductoDominio()
            {
                IdProducto = DTO.IdProducto,
                IdTipoProducto = DTO.IdTipoProducto,
                NumeroCuenta = DTO.NumeroCuenta,
                intEstado = DTO.intEstado,
                numSaldo = DTO.numSaldo,
                ExentaGMF = DTO.ExentaGMF,
                IdCliente = DTO.IdCliente
            };
        }

    }
}