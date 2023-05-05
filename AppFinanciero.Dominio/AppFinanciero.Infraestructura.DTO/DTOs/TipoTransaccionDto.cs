using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Infraestructura.DTO.DTOs
{
    public class TipoTransaccionDto
    {

        public int IdTipoTransaccion { get; set; }
        [Required]
        public string? strNombre { get; set; }

    }
}