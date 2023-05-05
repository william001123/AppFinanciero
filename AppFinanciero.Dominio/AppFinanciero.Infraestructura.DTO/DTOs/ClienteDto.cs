using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Infraestructura.DTO.DTOs
{
    public class ClienteDto
    {
        #region"Atributos"
        public int IdCliente { get; set; }

        [Required]
        public string? strTipoIdentificacion { get; set; }
        [Required]
        public string? strNumeroIdentificacion { get; set; }
        [Required]
        public string? strNombre { get; set; }
        [Required]
        public string? strApellido { get; set; }
        [Required]
        public string? strEmail { get; set; }
        [Required]
        public DateTime dtFechaNacimiento { get; set; }
        #endregion

        //#region"Constructor"

        //public ClienteDto()
        //{
        //    strTipoIdentificacion = String.Empty;
        //}

        //public ClienteDto(string _strTipoIdentificacion) {
        //    strTipoIdentificacion = _strTipoIdentificacion;
        //}

        //#endregion
    }
}