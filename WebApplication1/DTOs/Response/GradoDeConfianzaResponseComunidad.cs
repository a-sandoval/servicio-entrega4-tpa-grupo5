using ServicioCalculadorGradoDeConfianza.Domain.Confianza;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.DTOs.Response
{
    public class GradoDeConfianzaResponseComunidad
    {
        public Comunidad Comunidad { get; set; }

        public float NuevoPuntaje { get; set; }

        public GradoDeConfianza GradoDeConfianzaActual { get; set; }

          public GradoDeConfianzaResponseComunidad(Comunidad comunidad, float puntaje, GradoDeConfianza gradoDeConfianza) {

            Comunidad = comunidad; 
            NuevoPuntaje = puntaje; 
            GradoDeConfianzaActual = gradoDeConfianza; 

        } 
    }
}
