using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class ProductoEstadoRepositorio : IRepositorioBase<ProductoEstadoDominio, int>
    {

        private readonly FinancieroContexto db;

        public ProductoEstadoRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public void Eliminar(int entidadID)
        {
            var Selecc = db.ProductoEstado.Where(olinea => olinea.IdProductoEstado == entidadID).FirstOrDefault();

            if (Selecc != null)
            {
                db.ProductoEstado.Remove(Selecc);                               
            }
        }

        public List<ProductoEstadoDominio> ObtenerTodo()
        {
            return db.ProductoEstado.ToList().Map();
        }

        public ProductoEstadoDominio ObtenerPorID(int entidadID)
        {

            var Selecc = db.ProductoEstado.Where(olinea => olinea.IdProductoEstado == entidadID).FirstOrDefault();

            return Selecc.Map();
        }

        public ProductoEstadoDominio Insertar(ProductoEstadoDominio entidad)
        {
            //entidad.IdProductoEstado = new int();
            db.ProductoEstado.Add(entidad.Map());
            return entidad;
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }

        public void Actualizar(ProductoEstadoDominio entidad)
        {
            var Selecc = db.ProductoEstado.Where(olinea => olinea.IdProductoEstado == entidad.IdProductoEstado).FirstOrDefault();

            if (Selecc != null)
            {
                Selecc.strNombre = entidad.strNombre;
                
                db.Entry(Selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }
    }
}
