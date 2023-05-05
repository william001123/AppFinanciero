using AppFinanciero.Dominio.Modelos;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class ProductoMapper
    {
        public static Producto Map(this ProductoDominio model)
        {
            return new Producto()
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

        public static List<Producto> Map(this List<ProductoDominio> model)
        {
            List<Producto> Dtos = new List<Producto>();

            foreach (ProductoDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
            }

            return Dtos;
        }

        public static List<ProductoDominio> Map(this List<Producto> model)
        {
            List<ProductoDominio> Dtos = new List<ProductoDominio>();

            foreach (Producto modelItem in model)
            {
                Dtos.Add(Map(modelItem));
            }

            return Dtos;
        }

        public static ProductoDominio Map(this Producto DTO)
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