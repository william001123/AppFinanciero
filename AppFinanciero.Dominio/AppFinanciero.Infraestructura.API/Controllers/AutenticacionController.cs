using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Entidades;
using AppFinanciero.Infraestructura.DTO.Mappers;
using Microsoft.AspNetCore.Mvc;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFinanciero.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {

        private readonly IServicioAutenticacion<AutenticacionDominio, string> db;
        
        public AutenticacionController(IServicioAutenticacion<AutenticacionDominio, string> _db)
        {
            db = _db;            
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] AutenticacionDto autenticacion)
        {
            db.Insertar(autenticacion.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());
        }

        [HttpPost]
        [Route("Validar")]
        public ActionResult  ObtenerAutenticacion([FromBody] AutenticacionDto autenticacion)
        {
            var selec = db.ObtenerAutenticacion(autenticacion.Usuario, autenticacion.Contrasena).Map();

            if (selec != null)
            {
                var tokencreado = db.Token(autenticacion.Usuario);
                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
