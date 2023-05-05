using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioTransaccion<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, IListar<TEntidad, TEntidadID>, ISalvarTodo
    {
    }
}
