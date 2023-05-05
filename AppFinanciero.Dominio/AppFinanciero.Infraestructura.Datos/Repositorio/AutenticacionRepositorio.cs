using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class AutenticacionRepositorio : IRepositorioAutenticacion<AutenticacionDominio, string>
    {

        private FinancieroContexto db;

        public AutenticacionRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public AutenticacionDominio Insertar(AutenticacionDominio entidad)
        {
            db.Autenticacion.Add(entidad.Map());
            return entidad;
        }

        public AutenticacionDominio ObtenerAutenticacion(string Usuario, string Contrasena)
        {

            var Selecc = db.Autenticacion.Where(olinea => olinea.Usuario == Usuario && olinea.Contrasena == Contrasena).FirstOrDefault();

            return Selecc.Map();
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }        
    }
}
