using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Infraestructura.DTO.DTOs
{
    public class ProductoEstadoDto
    {
        public int IdProductoEstado { get; set; }
        [Required]
        public string? strNombre { get; set; }

    }
}