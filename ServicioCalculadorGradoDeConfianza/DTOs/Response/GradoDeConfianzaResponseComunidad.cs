using ServicioCalculadorGradoDeConfianza.Domain.Confianza;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.DTOs.Response
{
    public class GradoDeConfianzaResponseComunidad
    {
        public Comunidad Comunidad { get; set; }

        public float NuevoPuntaje { get; set; }

        public string GradoDeConfianzaActual { get; set; }

          public GradoDeConfianzaResponseComunidad(Comunidad comunidad, float puntaje, string gradoDeConfianza) {

            Comunidad = comunidad; 
            NuevoPuntaje = puntaje; 
            GradoDeConfianzaActual = gradoDeConfianza; 

        } 
    }
}
