using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBaseActualizar<TEntidad, TEntidadID>
        :IInsertar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ISalvarTodo
    {
        void ActualizarEstado(TEntidad entidad);
        void ActualizarSaldo(TEntidad entidad);
    }
}
