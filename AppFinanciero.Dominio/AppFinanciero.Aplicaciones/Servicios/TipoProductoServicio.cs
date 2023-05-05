using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Aplicaciones.Maestras;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class TipoProductoServicio
        : IServicioBase<TipoProductoDominio, int>
    {
        private readonly IRepositorioBase<TipoProductoDominio, int> repoTipoProducto;
        private Excepcion excepcion = new Excepcion();

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public TipoProductoServicio(IRepositorioBase<TipoProductoDominio, int> _repoTipoProducto)
        {
            repoTipoProducto = _repoTipoProducto;
        }

        public void Eliminar(int entidadID)
        {
            repoTipoProducto.Eliminar(entidadID);
            repoTipoProducto.SalvarTodo();
        }

        public List<TipoProductoDominio> ObtenerTodo()
        {
            return repoTipoProducto.ObtenerTodo();
        }

        public TipoProductoDominio ObtenerPorID(int entidadID)
        {
            return repoTipoProducto.ObtenerPorID(entidadID);
        }

        public TipoProductoDominio Insertar(TipoProductoDominio entidad)
        {
            try
            {
                var resultProductoEstado = repoTipoProducto.Insertar(entidad);
                repoTipoProducto.SalvarTodo();
                return resultProductoEstado;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }

            
        }

        public void Actualizar(TipoProductoDominio entidad)
        {
            try
            {
                if (entidad.IdTipoProducto == 0 || entidad.strNombre == "")
                    throw new ArgumentNullException("No se pudo Insertarar, verifique que los datos estén correctos o comuníquese con el área de TI");

                repoTipoProducto.Actualizar(entidad);
                repoTipoProducto.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }            
        }
    }
}
