using AppFinanciero.Dominio.Modelos;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente Map(this ClienteDominio model)
        {
            return new Cliente()
            {
                IdCliente = model.IdCliente,
                strTipoIdentificacion = model.strTipoIdentificacion,
                strNumeroIdentificacion = model.strNumeroIdentificacion,
                strNombre = model.strNombre,
                strApellido = model.strApellido,
                strEmail = model.strEmail,
                dtFechaNacimiento = model.dtFechaNacimiento
            };
        }

        public static List<Cliente> Map(this List<ClienteDominio> model)
        {
            List<Cliente> Dtos = new List<Cliente>();

            foreach (ClienteDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //clienteDtos.Add(new ClienteDto(modelItem.strNumeroIdentificacion));
            }

            return Dtos;
        }

        public static List<ClienteDominio> Map(this List<Cliente> model)
        {
            List<ClienteDominio> Dtos = new List<ClienteDominio>();

            foreach (Cliente modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //clienteDtos.Add(new ClienteDto(modelItem.strNumeroIdentificacion));
            }

            return Dtos;
        }

        public static ClienteDominio Map(this Cliente DTO)
        {
            return new ClienteDominio()
            {
                IdCliente = DTO.IdCliente,
                strTipoIdentificacion = DTO.strTipoIdentificacion,
                strNumeroIdentificacion = DTO.strNumeroIdentificacion,
                strNombre = DTO.strNombre,
                strApellido = DTO.strApellido,
                strEmail = DTO.strEmail,
                dtFechaNacimiento = DTO.dtFechaNacimiento
            };
        }

    }
}