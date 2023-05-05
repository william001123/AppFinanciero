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
    public class ProductoEstadoController : ControllerBase
    {

        private readonly IServicioBase<ProductoEstadoDominio, int> db;

        private ProductoEstadoController(IServicioBase<ProductoEstadoDominio, int> _db)
        {
            db = _db;
        }    

        [HttpGet]
        public ActionResult<List<ProductoEstadoDto>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<ProductoEstadoDto>> ObtenetPorID(int id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] ProductoEstadoDto ProductoEstado)
        {
            db.Insertar(ProductoEstado.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        [HttpPut("{id}")]
        public ActionResult Actualizar(int id, [FromBody] ProductoEstadoDto ProductoEstado)
        {

            ProductoEstado.IdProductoEstado = id;
            db.Actualizar(ProductoEstado.Map());
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
