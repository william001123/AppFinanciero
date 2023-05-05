using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class TipoProductoRepositorio : IRepositorioBase<TipoProductoDominio, int>
    {

        private readonly FinancieroContexto db;

        public TipoProductoRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public void Eliminar(int entidadID)
        {
            var Selecc = db.TipoProducto.Where(olinea => olinea.IdTipoProducto == entidadID).FirstOrDefault();

            if (Selecc != null)
            {
                db.TipoProducto.Remove(Selecc);                               
            }
        }

        public List<TipoProductoDominio> ObtenerTodo()
        {
            return db.TipoProducto.ToList().Map();
        }

        public TipoProductoDominio ObtenerPorID(int entidadID)
        {

            var Selecc = db.TipoProducto.Where(olinea => olinea.IdTipoProducto == entidadID).FirstOrDefault();

            return Selecc.Map();
        }

        public TipoProductoDominio Insertar(TipoProductoDominio entidad)
        {
            //entidad.IdTipoProducto = new int();
            db.TipoProducto.Add(entidad.Map());
            return entidad;
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }

        public void Actualizar(TipoProductoDominio entidad)
        {
            var Selecc = db.TipoProducto.Where(olinea => olinea.IdTipoProducto == entidad.IdTipoProducto).FirstOrDefault();

            if (Selecc != null)
            {
                Selecc.strNombre = entidad.strNombre;  

                db.Entry(Selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
    }
}
