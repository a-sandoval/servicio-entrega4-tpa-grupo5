using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.DTOs.Response
{
    public class GradoDeConfianzaResponseUsuario
    {
        public Usuario usuario { get; set; }

        public float NuevoPuntaje { get; set; }

        public string GradoDeConfianzaActual { get; set; }

        public bool DebeSerDesactivado { get; set; }
    }
}
