using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Aplicaciones.Maestras;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class ProductoServicio
        : IServicioBaseActualizar<ProductoDominio, int>
    {
        private readonly IRepositorioBaseActualizar<ProductoDominio, int> repoProducto;
        private Excepcion excepcion = new Excepcion();        

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public ProductoServicio(IRepositorioBaseActualizar<ProductoDominio, int> _repoProducto)
        {
            repoProducto = _repoProducto;
        }

        public void Eliminar(int entidadID)
        {
            repoProducto.Eliminar(entidadID);
            repoProducto.SalvarTodo();
        }

        public List<ProductoDominio> ObtenerTodo()
        {
            return repoProducto.ObtenerTodo();
        }

        public ProductoDominio ObtenerPorID(int entidadID)
        {
            return repoProducto.ObtenerPorID(entidadID);
        }

        public ProductoDominio Insertar(ProductoDominio entidad)
        {
            try
            {
                if (entidad.IdTipoProducto == 0 || entidad.numSaldo == 0 || entidad.ExentaGMF == "" || entidad.IdCliente == 0)
                    throw new ArgumentNullException(Error.Insertar.GetEnumDescription());

                var resultCliente = repoProducto.Insertar(entidad);
                repoProducto.SalvarTodo();
                return resultCliente;
            }          
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }            
        }

        public void ActualizarEstado(ProductoDominio entidad)
        {
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException(Error.Actualizar.GetEnumDescription());

                repoProducto.ActualizarEstado(entidad);
                repoProducto.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }
            
        }

        public void ActualizarSaldo(ProductoDominio entidad)
        { 
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException(Error.Actualizar.GetEnumDescription());

                repoProducto.ActualizarSaldo(entidad);
                repoProducto.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }
        }
    }
}
