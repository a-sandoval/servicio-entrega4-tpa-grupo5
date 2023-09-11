using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.DTOs.Request
{
    public class ComunidadRequest
    {
        public Comunidad Comunidad { get; set; }

        public List<Incidente> Incidentes { get; set; }
    }
}
