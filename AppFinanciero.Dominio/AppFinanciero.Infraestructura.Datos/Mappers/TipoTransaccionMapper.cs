using AppFinanciero.Dominio.Modelos;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class TipoTransaccionMapper
    {
        public static TipoTransaccion Map(this TipoTransaccionDominio model)
        {
            return new TipoTransaccion()
            {
                IdTipoTransaccion = model.IdTipoTransaccion,
                strNombre = model.strNombre,
            };
        }

        public static List<TipoTransaccion> Map(this List<TipoTransaccionDominio> model)
        {
            List<TipoTransaccion> Dtos = new List<TipoTransaccion>();

            foreach (TipoTransaccionDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static List<TipoTransaccionDominio> Map(this List<TipoTransaccion> model)
        {
            List<TipoTransaccionDominio> Dtos = new List<TipoTransaccionDominio>();

            foreach (TipoTransaccion modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //tipoProductoDtos.Add(new TipoProductoDto(modelItem.strNombre));
            }

            return Dtos;
        }

        public static TipoTransaccionDominio Map(this TipoTransaccion DTO)
        {
            return new TipoTransaccionDominio()
            {
                IdTipoTransaccion = DTO.IdTipoTransaccion,
                strNombre = DTO.strNombre                
            };
        }

    }
}