using AppFinanciero.Dominio.Modelos;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class ProductoEstadoMapper
    {
        public static ProductoEstado Map(this ProductoEstadoDominio model)
        {
            return new ProductoEstado()
            {
                IdProductoEstado = model.IdProductoEstado,
                strNombre = model.strNombre,                
            };
        }

        public static List<ProductoEstado> Map(this List<ProductoEstadoDominio> model)
        {
            List<ProductoEstado> Dtos = new List<ProductoEstado>();

            foreach (ProductoEstadoDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static List<ProductoEstadoDominio> Map(this List<ProductoEstado> model)
        {
            List<ProductoEstadoDominio> Dtos = new List<ProductoEstadoDominio>();

            foreach (ProductoEstado modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static ProductoEstadoDominio Map(this ProductoEstado DTO)
        {
            return new ProductoEstadoDominio()
            {
                IdProductoEstado = DTO.IdProductoEstado,
                strNombre = DTO.strNombre                
            };
        }

    }
}