using AppFinanciero.Aplicaciones.Interfaces;
using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using AppFinanciero.Aplicaciones.Maestras;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class TransaccionServicio
        : IServicioTransaccion<TransaccionDominio, int>
    {
        private readonly IRepositorioTransaccion<TransaccionDominio, int> repoTransaccion;
        private readonly IServicioBaseActualizar<ProductoDominio, int> servProducto;
        private readonly IServicioBase<TipoTransaccionDominio, int> servTipoTransaccion;
        private Excepcion excepcion = new Excepcion();

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public TransaccionServicio(IRepositorioTransaccion<TransaccionDominio, int> _repoTransaccion,
            IServicioBaseActualizar<ProductoDominio, int> _servProducto,
            IServicioBase<TipoTransaccionDominio, int> _servTipoTransaccion)
        {
            repoTransaccion = _repoTransaccion;
            servProducto = _servProducto;
            servTipoTransaccion = _servTipoTransaccion;
        }

        public List<TransaccionDominio> ObtenerTodo()
        {
            return repoTransaccion.ObtenerTodo();
        }

        public TransaccionDominio ObtenerPorID(int entidadID)
        {
            return repoTransaccion.ObtenerPorID(entidadID);
        }

        public TransaccionDominio Insertar(TransaccionDominio entidad)
        {
            try
            {
                if (entidad == null)
                    throw new Exception("");

                //Producto origen
                var productoOrigen = servProducto.ObtenerPorID(entidad.IdProductoOrigen);
                var numSaldoOrigen = productoOrigen.numSaldo - entidad.numSaldo;

                //Producto destino
                var productoDestino = servProducto.ObtenerPorID(entidad.IdProductoDestino);
                var numSaldoDestino = productoDestino.numSaldo + entidad.numSaldo;

                switch (entidad.IdTransaccion)
                {
                    case 1:
                        //Consignaciones
                        //Validación para el producto destino
                        if (productoDestino == null || productoDestino.intEstado != 1)
                            throw new Exception(ErrorProducto.InsertarProdDest.GetEnumDescription());

                        //Validacion para obligar que no Insertaren producto origen en las consiganciones
                        entidad.IdProductoOrigen = 0;

                        //Se suma el saldo en el producto destino
                        servProducto.ActualizarSaldo(productoDestino);

                        break;
                    case 2:
                        //Retiros
                        //Validación para el producto origen

                        if (productoOrigen == null || productoOrigen.intEstado != 1)
                            throw new Exception(ErrorProducto.InsertarProdOrig.GetEnumDescription());

                        if (numSaldoOrigen < 0)
                            throw new Exception(ErrorProducto.InsertarProdOrigSal.GetEnumDescription());

                        //Validacion para obligar que no Insertaren producto destino en los retiros
                        entidad.IdProductoDestino = 0;

                        //Se resta el saldo en el producto origen
                        servProducto.ActualizarSaldo(productoOrigen);

                        break;

                    case 3:
                        //Transferencia entre cuentas
                        //Validación para el producto origen       
                        if (productoOrigen == null || productoOrigen.intEstado != 1)
                            throw new Exception(ErrorProducto.InsertarProdOrig.GetEnumDescription());

                        //Validación para el producto destino
                        if (productoDestino == null || productoDestino.intEstado != 1)
                            throw new Exception(ErrorProducto.InsertarProdDest.GetEnumDescription());

                        if (numSaldoOrigen < 0)
                            throw new Exception(ErrorProducto.InsertarProdOrigSal.GetEnumDescription());


                        //Se resta el saldo en el producto origen
                        servProducto.ActualizarSaldo(productoDestino);

                        //Se suma el saldo en el producto destino
                        servProducto.ActualizarSaldo(productoOrigen);

                        break;

                    default:
                        throw new Exception(ErrorProducto.TipoTransaccion.GetEnumDescription());
                }

                var resultTransaccion = repoTransaccion.Insertar(entidad);

                repoTransaccion.SalvarTodo();
                return resultTransaccion;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }            
        }
    }
}
