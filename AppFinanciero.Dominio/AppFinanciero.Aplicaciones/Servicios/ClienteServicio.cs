using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;
using AppFinanciero.Aplicaciones.Maestras;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class ClienteServicio
        : IServicioBase<ClienteDominio, int>
    {
        private readonly IRepositorioBase<ClienteDominio, int> repoCliente;
        private Excepcion excepcion = new Excepcion();

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public ClienteServicio(IRepositorioBase<ClienteDominio, int> _repoCliente)
        {
            repoCliente = _repoCliente;
        }

        public void Eliminar(int entidadID)
        {
            repoCliente.Eliminar(entidadID);
            repoCliente.SalvarTodo();
        }

        public List<ClienteDominio> ObtenerTodo()
        {
            return repoCliente.ObtenerTodo();
        }

        public ClienteDominio ObtenerPorID(int entidadID)
        {
            return repoCliente.ObtenerPorID(entidadID);
        }

        public ClienteDominio Insertar(ClienteDominio entidad)
        {
            try
            {               
                var resultCliente = repoCliente.Insertar(entidad);
                repoCliente.SalvarTodo();
                return resultCliente;
            }
            catch (Exception ex)
            {                
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }            
        }        

        public void Actualizar(ClienteDominio entidad)
        {
            try
            {            
                repoCliente.Actualizar(entidad);
                repoCliente.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }            
        }
    }
}
