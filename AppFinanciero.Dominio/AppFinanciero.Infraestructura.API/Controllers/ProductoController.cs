using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Aplicaciones.Servicios;
using AppFinanciero.Dominio.Interfaces.Repositorio;
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
    public class ProductoController : ControllerBase
    {

        private readonly IServicioBaseActualizar<ProductoDominio, int> db;

        private ProductoController(IServicioBaseActualizar<ProductoDominio, int> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<ProductoDto>> ObtenerTodo()
        {     
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<ProductoDto>> ObtenetPorID(int id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] ProductoDto Producto)
        {
            db.Insertar(Producto.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        [HttpPut("{id}")]
        public ActionResult ActualizarEstado(int id, [FromBody] ProductoDto Producto)
        {
            Producto.IdProducto = id;
            db.ActualizarEstado(Producto.Map());
            return Ok(Satisfactorio.Actualizado.GetEnumDescription());
        }

        [HttpPut("{id}")]
        public ActionResult ActualizarSaldo(int id, [FromBody] ProductoDto Producto)
        {
            Producto.IdProducto = id;
            db.ActualizarSaldo(Producto.Map());
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
