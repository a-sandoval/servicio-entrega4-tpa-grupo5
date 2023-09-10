using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.DTOs.Request
{
    public class UsuarioRequest
    {
        public Usuario Usuario { get; set; }

        public List<Incidente> Incidentes { get; set; }

    }
}
