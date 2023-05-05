using AppFinanciero.Dominio.Interfaces;
using AppFinanciero.Infraestructura.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppFinanciero.Infraestructura.API.Interfaces
{
    public interface IApiBase<TEntidad, TEntidadID>
    {
        public ActionResult<List<TEntidad>> ObtenerTodo();

        public ActionResult<List<TEntidad>> ObtenetPorID(TEntidadID id);
        public ActionResult Insertar([FromBody] TEntidad entidad);
        public ActionResult Actualizar(TEntidadID id, [FromBody] TEntidad cliente);
        public ActionResult Eliminar(TEntidadID id);

    }
}
