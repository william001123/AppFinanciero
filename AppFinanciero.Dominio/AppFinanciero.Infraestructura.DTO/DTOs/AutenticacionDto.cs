using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Infraestructura.Datos.Entidades
{
    public class AutenticacionDto
    {
        [Required]
        public string? Usuario { get; set; }
        [Required]
        public string? Contrasena { get; set; }
    }
}
