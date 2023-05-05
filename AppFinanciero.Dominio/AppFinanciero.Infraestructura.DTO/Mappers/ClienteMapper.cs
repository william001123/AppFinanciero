using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteDto Map(this ClienteDominio model)
        {
            return new ClienteDto()
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

        public static List<ClienteDto> Map(this List<ClienteDominio> model)
        {
            List<ClienteDto> Dtos = new List<ClienteDto>();

            foreach (ClienteDominio modelItem in model)
            {
                Dtos.Add(Map(modelItem));
                //clienteDtos.Add(new ClienteDto(modelItem.strNumeroIdentificacion));
            }

            return Dtos;
        }

        public static ClienteDominio Map(this ClienteDto DTO)
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