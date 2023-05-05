using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciero.Infraestructura.API.Maestras
{
    public class Excepcion
    {

        public static Exception Error(Exception ex, string _Mensaje)
        {
            //El ex va a funcionar para el Log
            string strMensaje = "";
            try
            {

            }
            catch (ArgumentNullException)
            {
                strMensaje = "Valores nulos";
            }
            catch (DirectoryNotFoundException)
            {
                strMensaje = "El directorio no es válido";
            }
            catch (FormatException)
            {
                strMensaje = "El formato no es válido";
            }
            catch (TimeoutException)
            {
                strMensaje = "El intervalo de tiempo asignado a una operación ha expirado.";
            }

            throw new Exception(strMensaje);
        }
    }
}
