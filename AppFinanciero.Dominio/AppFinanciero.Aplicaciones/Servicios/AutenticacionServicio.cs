using AppFinanciero.Dominio.Modelos;
using AppFinanciero.Dominio.Interfaces.Repositorio;
using static AppFinanciero.Aplicaciones.Maestras.MensajesBase;
using AppFinanciero.Aplicaciones.Maestras;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace AppFinanciero.Aplicaciones.Servicios
{
    public class AutenticacionServicio
        : IServicioAutenticacion<AutenticacionDominio, string>
    {
        private readonly IRepositorioAutenticacion<AutenticacionDominio, string> repo;
        private Excepcion excepcion = new Excepcion();
        private string secretKey = "";

        //El objeto que recibiremos es una clase concreta que implemente
        //la interfaz de repositorio y ejecute las operaciones en
        //alguna tecnologia sin necesidad que el servicio la reconozca
        public AutenticacionServicio(IRepositorioAutenticacion<AutenticacionDominio, string> _repo, IConfiguration config)
        {
            repo = _repo;
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
            //secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        public AutenticacionDominio Insertar(AutenticacionDominio entidad)
        {
            try
            {
                entidad.Contrasena = Encrypt.Encriptar(entidad.Contrasena);
                var result = repo.Insertar(entidad);
                repo.SalvarTodo();
                return result;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }
        }

        public AutenticacionDominio ObtenerAutenticacion(string Usuario, string Contrasena)
        {
            Contrasena = Encrypt.Encriptar(Contrasena);            
            return repo.ObtenerAutenticacion(Usuario, Contrasena);
        }

        public string Token(string Usuario)
        {
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Usuario));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokencreado = tokenHandler.WriteToken(tokenConfig);

            return tokencreado;
        }

    }
}
