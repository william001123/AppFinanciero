using AppFinanciero.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Aplicaciones.Interfaces
{
    public interface IServicioBaseActualizar<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {
        void ActualizarEstado(TEntidad entidad);
        void ActualizarSaldo(TEntidad entidad);
    }
}
