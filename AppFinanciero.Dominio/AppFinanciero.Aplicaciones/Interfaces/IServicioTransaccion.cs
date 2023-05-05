using AppFinanciero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Aplicaciones.Interfaces
{
    public interface IServicioTransaccion<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, IListar<TEntidad, TEntidadID>
    {
    }
}
