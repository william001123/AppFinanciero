using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Infraestructura.Datos.Contextos;
using AppFinanciero.Infraestructura.Datos.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Infraestructura.Datos.Repositorio
{
    public class ProductoRepositorio : IRepositorioBaseActualizar<ProductoDominio, int>
    {

        private readonly FinancieroContexto db;

        public ProductoRepositorio(FinancieroContexto _db)
        {
            db = _db;
        }

        public void Eliminar(int entidadID)
        {
            var Selecc = db.Producto.Where(olinea => olinea.IdProducto == entidadID).FirstOrDefault();

            if (Selecc != null)
            {
                db.Producto.Remove(Selecc);                               
            }
        }

        public List<ProductoDominio> ObtenerTodo()
        {
            return db.Producto.ToList().Map();
        }

        public ProductoDominio ObtenerPorID(int entidadID)
        {

            var Selecc = db.Producto.Where(olinea => olinea.IdProducto == entidadID).FirstOrDefault();

            return Selecc.Map();
        }

        public ProductoDominio Insertar(ProductoDominio entidad)
        {
            //entidad.IdProductoDominio = new int();
            db.Producto.Add(entidad.Map());
            return entidad;
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }

        public void ActualizarEstado(ProductoDominio entidad)
        {
            var Selecc = db.Producto.Where(olinea => olinea.IdProducto == entidad.IdProducto).FirstOrDefault();

            if (Selecc != null)
            {
                Selecc.intEstado = entidad.intEstado;

                db.Entry(Selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

        }

        public void ActualizarSaldo(ProductoDominio entidad)
        {
            var Selecc = db.Producto.Where(olinea => olinea.IdProducto == entidad.IdProducto).FirstOrDefault();

            if (Selecc != null)
            {
                Selecc.numSaldo = entidad.numSaldo;

                db.Entry(Selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
             
        }
    }
}
