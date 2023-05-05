using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Dominio.Interfaces.Repositorio
{
    public interface IServicioAutenticacion<TEntidad, TEntidadID>
        :IInsertar<TEntidad>
    {
        TEntidad ObtenerAutenticacion(TEntidadID Usuario, TEntidadID Contrasena);
        string Token(TEntidadID Usuario);
    }
}
