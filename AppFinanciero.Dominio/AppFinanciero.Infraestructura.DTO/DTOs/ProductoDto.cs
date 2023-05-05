using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Infraestructura.DTO.DTOs
{
    public class ProductoDto
    {

        public int IdProducto { get; set; }
        [Required]
        public int IdTipoProducto { get; set; }
        [Required]
        public string? NumeroCuenta { get; set; }
        [Required]
        public int intEstado { get; set; }
        [Required]
        public double numSaldo { get; set; }
        [Required]
        public string? ExentaGMF { get; set; }
        [Required]
        public int IdCliente { get; set; }

    }

}