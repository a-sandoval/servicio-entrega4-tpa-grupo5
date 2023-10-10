using ServicioCalculadorGradoDeConfianza.Domain.Confianza;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.DTOs.Response
{
    public class GradoDeConfianzaResponseUsuario
    {
        public Usuario Usuario { get; set; }

        public float NuevoPuntaje { get; set; }

        public string GradoDeConfianzaActual { get; set; }

        public GradoDeConfianzaResponseUsuario(Usuario usuario, float puntaje, string gradoDeConfianza) {

            Usuario = usuario; 
            NuevoPuntaje = puntaje; 
            GradoDeConfianzaActual = gradoDeConfianza; 

        } 
    }

    
}
