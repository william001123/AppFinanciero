using AppFinanciero.Aplicaciones.Servicios;
using AppFinanciero.Infraestructura.DTO;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static AppFinanciero.Infraestructura.API.Maestras.MensajesBase;
using AppFinanciero.Infraestructura.DTO.DTOs;
using AppFinanciero.Infraestructura.DTO.Mappers;
using System.Linq;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.API.Interfaces;
using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Infraestructura.API.Maestras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFinanciero.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]
    [Authorize]
    public class TipoProductoController : ControllerBase
    {

        private readonly IServicioBase<TipoProductoDominio, int> db;

        public TipoProductoController(IServicioBase<TipoProductoDominio, int> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<TipoProductoDto>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<TipoProductoDto>> ObtenetPorID(int id)
        {  
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] TipoProductoDto TipoProducto)
        {
            try
            {
                db.Insertar(TipoProducto.Map());
                return Ok(Satisfactorio.Insertado.GetEnumDescription());
            }
            catch (Exception ex)
            {
                throw Excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }            
        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] TipoProductoDto TipoProducto)
        {
            TipoProducto.IdTipoProducto = id;
            db.Actualizar(TipoProducto.Map());
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
