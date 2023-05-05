using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.DTO.DTOs;
using AppFinanciero.Infraestructura.DTO.Mappers;
using Microsoft.AspNetCore.Mvc;
using static AppFinanciero.Infraestructura.API.Maestras.MensajesBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFinanciero.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {

        private readonly IServicioTransaccion<TransaccionDominio, int> db;

        public TransaccionController(IServicioTransaccion<TransaccionDominio, int> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<TransaccionDto>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<TransaccionDto>> ObtenetPorID(int id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] TransaccionDto Transaccion)
        {
            db.Insertar(Transaccion.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }
    }
}
