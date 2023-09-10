using Microsoft.AspNetCore.Mvc;
using ServicioCalculadorGradoDeConfianza.Domain.calculadores;
using ServicioCalculadorGradoDeConfianza.DTOs.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Response;

namespace ServicioCalculadorGradoDeConfianza.Controllers
{
    [ApiController]
    [Route("gradoDeConfianza")]
    public class GradoDeConfianzaController : ControllerBase
    {
        private readonly CalculadorConfianzaComunidad calculadorConfianzaComunidad;
        private readonly CalculadorPuntajeConfianzaDeUsuario calculadorConfianzaUsuario;

        public GradoDeConfianzaController(CalculadorConfianzaComunidad calculador, CalculadorPuntajeConfianzaDeUsuario calculadorUsuario)
        {
            calculadorConfianzaComunidad = calculador;
            calculadorConfianzaUsuario = calculadorUsuario;
                
        }

        [HttpPost("usuario")]
        public ActionResult<GradoDeConfianzaResponseUsuario> ObtenerGradoDeConfianzaDeUsuario ([FromBody] UsuarioRequest usuarioRequest) {

            throw new NotImplementedException();
        }

        [HttpPost("comunidad")]
        public ActionResult<GradoDeConfianzaResponseComunidad> ObtenerGradoDeConfianzaDeComunidad([FromBody] ComunidadRequest comunidadRequest)
        {

            throw new NotImplementedException();
        }
    }
}