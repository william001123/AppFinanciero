using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class ClienteRepositorio : IRepositorioBase<ClienteDominio, int>
    {

        private FinancieroContexto db;

        public ClienteRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public void Eliminar(int entidadID)
        {
            var Selecc = db.Cliente.Where(olinea => olinea.IdCliente == entidadID).FirstOrDefault();

            if (Selecc != null)
            {
                db.Cliente.Remove(Selecc);                               
            }
        }

        public List<ClienteDominio> ObtenerTodo()
        {
            return db.Cliente.ToList().Map();
        }

        public ClienteDominio ObtenerPorID(int entidadID)
        {

            var Selecc = db.Cliente.Where(olinea => olinea.IdCliente == entidadID).FirstOrDefault();

            return Selecc.Map();
        }

        public ClienteDominio Insertar(ClienteDominio entidad)
        {
            //entidad.IdCliente = new int();
            db.Cliente.Add(entidad.Map());
            return entidad;
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }

        public void Actualizar(ClienteDominio entidad)
        {
            var Selecc = db.Cliente.Where(olinea => olinea.IdCliente == entidad.IdCliente).FirstOrDefault();

            if (Selecc != null)
            {
                Selecc.strTipoIdentificacion = entidad.strTipoIdentificacion;
                Selecc.strNumeroIdentificacion = entidad.strNumeroIdentificacion;
                Selecc.strNombre = entidad.strNombre;
                Selecc.strApellido = entidad.strApellido;
                Selecc.strEmail = entidad.strEmail;
                Selecc.dtFechaCreacion = entidad.dtFechaCreacion;

                db.Entry(Selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
    }
}
