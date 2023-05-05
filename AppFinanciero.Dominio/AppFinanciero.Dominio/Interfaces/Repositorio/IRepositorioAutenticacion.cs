﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioAutenticacion<TEntidad, TEntidadID>
        :IInsertar<TEntidad>, ISalvarTodo
    {
        TEntidad ObtenerAutenticacion(TEntidadID Usuario, TEntidadID Contrasena);
    }
}
