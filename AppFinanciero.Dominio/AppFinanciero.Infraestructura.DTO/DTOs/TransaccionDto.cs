using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Infraestructura.DTO.DTOs
{
    public class TransaccionDto
    {
        public int IdTransaccion { get; set; }
        [Required]
        public int IdTipoTransaccion { get; set; }
        [Required]
        public double numSaldo { get; set; }
        [Required]
        public int IdProductoOrigen { get; set; }
        [Required]
        public int IdProductoDestino { get; set; }
    }
}