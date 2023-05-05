using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Aplicaciones.Servicios;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Repositorio;
using AppFinanciero.Infraestructura.DTO.DTOs;
using AppFinanciero.Infraestructura.DTO.Mappers;
using Microsoft.AspNetCore.Mvc;
using static AppFinanciero.Infraestructura.API.Maestras.MensajesBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFinanciero.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransaccionController : ControllerBase
    {

        private readonly IServicioBase<TipoTransaccionDominio, int> db;

        public TipoTransaccionController(IServicioBase<TipoTransaccionDominio, int> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<TipoTransaccionDto>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<TipoTransaccionDto>> ObtenetPorID(int id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] TipoTransaccionDto TipoTransaccion)
        {
            db.Insertar(TipoTransaccion.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] TipoTransaccionDto TipoTransaccion)
        {
            TipoTransaccion.IdTipoTransaccion = id;
            db.Actualizar(TipoTransaccion.Map());
            return Ok(Satisfactorio.Actualizado.GetEnumDescription());
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            db.Eliminar(id);
            return Ok(Satisfactorio.Eliminado.GetEnumDescription());
        }
    }
}
