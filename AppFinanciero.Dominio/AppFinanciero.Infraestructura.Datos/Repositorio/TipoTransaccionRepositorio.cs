using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class TipoTransaccionRepositorio : IRepositorioBase<TipoTransaccionDominio, int>
    {

        private readonly FinancieroContexto db;

        public TipoTransaccionRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public void Eliminar(int entidadID)
        {
            var Selecc = db.TipoTransaccion.Where(olinea => olinea.IdTipoTransaccion == entidadID).FirstOrDefault();

            if (Selecc != null)
            {
                db.TipoTransaccion.Remove(Selecc);                               
            }
        }

        public List<TipoTransaccionDominio> ObtenerTodo()
        {
            return db.TipoTransaccion.ToList().Map();
        }

        public TipoTransaccionDominio ObtenerPorID(int entidadID)
        {

            var Selecc = db.TipoTransaccion.Where(olinea => olinea.IdTipoTransaccion == entidadID).FirstOrDefault();

            return Selecc.Map();
        }

        public TipoTransaccionDominio Insertar(TipoTransaccionDominio entidad)
        {
            //entidad.IdTipoTransaccion = new int();
            db.TipoTransaccion.Add(entidad.Map());
            return entidad;
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }

        public void Actualizar(TipoTransaccionDominio entidad)
        {
            var Selecc = db.TipoTransaccion.Where(olinea => olinea.IdTipoTransaccion == entidad.IdTipoTransaccion).FirstOrDefault();

            if (Selecc != null)
            {
                Selecc.strNombre = entidad.strNombre;    

                db.Entry(Selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
    }
}
