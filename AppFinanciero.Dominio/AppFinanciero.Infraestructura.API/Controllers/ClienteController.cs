using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Aplicaciones.Servicios;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.API.Interfaces;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Repositorio;
using AppFinanciero.Infraestructura.DTO.DTOs;
using AppFinanciero.Infraestructura.DTO.Mappers;
using Microsoft.AspNetCore.Mvc;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFinanciero.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IServicioBase<ClienteDominio, int> db;

        private ClienteController(IServicioBase<ClienteDominio, int> _db)
        {
            db = _db;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<List<ClienteDto>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<List<ClienteDto>> ObtenetPorID(int id)
        {    
            return Ok(db.ObtenerPorID(id).Map());
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Insertar([FromBody] ClienteDto cliente)
        {
            db.Insertar(cliente.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] ClienteDto cliente)
        {
            cliente.IdCliente = id;
            db.Actualizar(cliente.Map());
            return Ok(Satisfactorio.Actualizado.GetEnumDescription());
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Eliminar(int id)
        {
            db.Eliminar(id);            
        }  
    }
}
