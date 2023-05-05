using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class TransaccionRepositorio : IRepositorioTransaccion<TransaccionDominio, int>
    {

        private readonly FinancieroContexto db;

        public TransaccionRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public List<TransaccionDominio> ObtenerTodo()
        {
            return db.Transaccion.ToList().Map();
        }

        public TransaccionDominio ObtenerPorID(int entidadID)
        {

            var Selecc = db.Transaccion.Where(olinea => olinea.IdTransaccion == entidadID).FirstOrDefault();

            return Selecc.Map();
        }

        public TransaccionDominio Insertar(TransaccionDominio entidad)
        {
            //entidad.IdTransaccion = new int();
            db.Transaccion.Add(entidad.Map());
            return entidad;
        }        

        public void SalvarTodo()
        {
            db.SaveChanges();
        }
    }
}
