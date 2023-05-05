using AppFinanciero.Dominio.Modelos;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class TipoProductoMapper
    {
        public static TipoProducto Map(this TipoProductoDominio model)
        {
            return new TipoProducto()
            {
                IdTipoProducto = model.IdTipoProducto,
                strNombre = model.strNombre,                
            };
        }

        public static List<TipoProducto> Map(this List<TipoProductoDominio> model)
        {
            List<TipoProducto> tipoProductoDtos = new List<TipoProducto>();

            foreach (TipoProductoDominio modelItem in model)
            {
                tipoProductoDtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return tipoProductoDtos;
        }

        public static List<TipoProductoDominio> Map(this List<TipoProducto> model)
        {
            List<TipoProductoDominio> tipoProductoDtos = new List<TipoProductoDominio>();

            foreach (TipoProducto modelItem in model)
            {
                tipoProductoDtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return tipoProductoDtos;
        }

        public static TipoProductoDominio Map(this TipoProducto DTO)
        {
            return new TipoProductoDominio()
            {
                IdTipoProducto = DTO.IdTipoProducto,
                strNombre = DTO.strNombre                
            };
        }

    }
}