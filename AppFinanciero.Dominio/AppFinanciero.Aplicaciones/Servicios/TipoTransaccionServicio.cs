using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Aplicaciones.Maestras;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class TipoTransaccionServicio
        : IServicioBase<TipoTransaccionDominio, int>
    {
        private readonly IRepositorioBase<TipoTransaccionDominio, int> repoTipoTransaccion;
        private Excepcion excepcion = new Excepcion();

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public TipoTransaccionServicio(IRepositorioBase<TipoTransaccionDominio, int> _repoTipoTransaccion)
        {
            repoTipoTransaccion = _repoTipoTransaccion;
        }

        public void Eliminar(int entidadID)
        {
            repoTipoTransaccion.Eliminar(entidadID);
            repoTipoTransaccion.SalvarTodo();
        }

        public List<TipoTransaccionDominio> ObtenerTodo()
        {
            return repoTipoTransaccion.ObtenerTodo();
        }

        public TipoTransaccionDominio ObtenerPorID(int entidadID)
        {
            return repoTipoTransaccion.ObtenerPorID(entidadID);
        }

        public TipoTransaccionDominio Insertar(TipoTransaccionDominio entidad)
        {
            try
            {
                if (entidad.strNombre == "")
                    throw new Exception(Error.Insertar.GetEnumDescription());

                var resultProductoEstado = repoTipoTransaccion.Insertar(entidad);
                repoTipoTransaccion.SalvarTodo();
                return resultProductoEstado;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }            
        }

        public void Actualizar(TipoTransaccionDominio entidad)
        {
            try
            {
                if (entidad.IdTipoTransaccion == 0 || entidad.strNombre == "")
                    throw new Exception(Error.Actualizar.GetEnumDescription());

                repoTipoTransaccion.Actualizar(entidad);
                repoTipoTransaccion.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }

            
        }
    }
}
