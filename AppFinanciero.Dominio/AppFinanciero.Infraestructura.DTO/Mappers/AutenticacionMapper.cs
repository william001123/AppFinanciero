using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Entidades;
using AppFinanciero.Infraestructura.DTO.DTOs;

namespace AppFinanciero.Infraestructura.DTO.Mappers
{
    public static class AutenticacionMapper
    {
        public static AutenticacionDto Map(this AutenticacionDominio model)
        {
            return new AutenticacionDto()
            {
                Usuario = model.Usuario,
                Contrasena = model.Contrasena
            };
        }

        public static AutenticacionDominio Map(this AutenticacionDto DTO)
        {
            return new AutenticacionDominio()
            {
                Usuario = DTO.Usuario,
                Contrasena = DTO.Contrasena
            };
        }

    }
}