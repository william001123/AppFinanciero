using System.ComponentModel.DataAnnotations;

namespace AppFinanciero.Infraestructura.DTO.DTOs
{
    public class TipoProductoDto
    {
        #region "Atributos"
        public int IdTipoProducto { get; set; }
        [Required]
        public string? strNombre { get; set; }
        #endregion

        //#region "Contructores"

        //public TipoProductoDto() {
        //    IdTipoProducto = 0;
        //    strNombre = String.Empty;
        //}

        //public TipoProductoDto(int _IdTipoProducto, string _strNombre)
        //{
        //    IdTipoProducto = _IdTipoProducto;
        //    strNombre = _strNombre;
        //}

        //#endregion
    }
}