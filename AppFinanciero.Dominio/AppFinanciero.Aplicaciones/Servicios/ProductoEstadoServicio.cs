using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Aplicaciones.Maestras;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;
using System;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class ProductoEstadoServicio
        : IServicioBase<ProductoEstadoDominio, int>
    {
        private readonly IRepositorioBase<ProductoEstadoDominio, int> repoProductoEstado;
        private Excepcion excepcion = new Excepcion();

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public ProductoEstadoServicio(IRepositorioBase<ProductoEstadoDominio, int> _repoCliente)
        {
            repoProductoEstado = _repoCliente;
        }

        public void Eliminar(int entidadID)
        {
            repoProductoEstado.Eliminar(entidadID);
            repoProductoEstado.SalvarTodo();
        }

        public List<ProductoEstadoDominio> ObtenerTodo()
        {
            return repoProductoEstado.ObtenerTodo();
        }

        public ProductoEstadoDominio ObtenerPorID(int entidadID)
        {
            return repoProductoEstado.ObtenerPorID(entidadID);
        }

        public ProductoEstadoDominio Insertar(ProductoEstadoDominio entidad)
        {
            try
            {
                if (entidad.strNombre == "")
                    throw new Exception(Error.Insertar.GetEnumDescription());

                var resultProductoEstado = repoProductoEstado.Insertar(entidad);
                repoProductoEstado.SalvarTodo();
                return resultProductoEstado;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }
        }

        public void Actualizar(ProductoEstadoDominio entidad)
        {
            try
            {
                if (entidad.IdProductoEstado == 0 || entidad.strNombre == "")
                    throw new Exception(Error.Actualizar.GetEnumDescription());

                repoProductoEstado.Actualizar(entidad);
                repoProductoEstado.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }

            
        }
    }
}
