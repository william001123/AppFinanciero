using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Dominio.Modelos
{
    public class ClienteDominio
    {        
        public int IdCliente { get; set; }
        public string? strTipoIdentificacion { get; set; }
        public string? strNumeroIdentificacion { get; set; }
        public string? strNombre { get; set; }
        public string? strApellido { get; set; }
        public string? strEmail { get; set; }
        public DateTime dtFechaNacimiento { get; set; }
        public DateTime dtFechaCreacion { get; set; }
        public DateTime dtFechaModificacion { get; set; }

        public List<ProductoDominio>? Producto { get; set; }

    }
}