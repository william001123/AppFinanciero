using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Entidades;

namespace AppFinanciero.Infraestructura.Datos.Mappers
{
    public static class AutenticacionMapper
    {
        public static Autenticacion Map(this AutenticacionDominio model)
        {
            return new Autenticacion()
            {
                Usuario = model.Usuario,
                Contrasena = model.Contrasena
            };
        }

        public static AutenticacionDominio Map(this Autenticacion DTO)
        {
            return new AutenticacionDominio()
            {
                Usuario = DTO.Usuario,
                Contrasena = DTO.Contrasena
            };
        }

    }
}