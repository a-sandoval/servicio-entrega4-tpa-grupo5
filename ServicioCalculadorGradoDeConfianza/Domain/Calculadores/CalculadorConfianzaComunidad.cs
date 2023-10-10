using ServicioCalculadorGradoDeConfianza.Domain.Calculadores;
using ServicioCalculadorGradoDeConfianza.Domain.Confianza;
using ServicioCalculadorGradoDeConfianza.DTOs.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Response;

namespace ServicioCalculadorGradoDeConfianza.Domain.calculadores
{

    public class CalculadorConfianzaComunidad
    {   
        public GradoDeConfianzaResponseComunidad ObtenerGradoDeConfianzaResponse(ComunidadRequest comunidadRequest) {

            float puntaje = CalcularPuntajeDeConfianza(comunidadRequest.Comunidad, comunidadRequest.Incidentes);

            GradoDeConfianza grado = CalcularGradoDeConfianza(comunidadRequest.Comunidad, comunidadRequest.Incidentes); 

            GradoDeConfianzaConverter converter = new(); 

            return new GradoDeConfianzaResponseComunidad(comunidadRequest.Comunidad, puntaje,converter.Convertir(grado)); 
        }
        public GradoDeConfianza CalcularGradoDeConfianza(Comunidad comunidad, List<Incidente> incidentes)
        {

            float puntajeConfianzaComunidad = CalcularPuntajeDeConfianza(comunidad, incidentes);

            CalculadorGradoDeConfianza calculadoraGrado = new();

            return calculadoraGrado.CalcularGradoDeConfianza(puntajeConfianzaComunidad);
        }


        private float CalcularPuntajeDeConfianza(Comunidad comunidad, List<Incidente> incidentes)
        {

            int cantidadDeMiembros = comunidad.Miembros.Count;
            float puntajeConfianzaTotal = 0;

            CalculadorPuntajeConfianzaDeUsuario calculador = new CalculadorPuntajeConfianzaDeUsuario();
            CalculadorGradoDeConfianza calculadorGrado = new();

            foreach (Usuario miembro in comunidad.Miembros)
            {

                float puntajeMiembro = calculador.CalcularPuntajeConfianza(miembro, incidentes);
                puntajeConfianzaTotal += puntajeMiembro;

                if (calculadorGrado.CalcularGradoDeConfianza(puntajeMiembro) == GradoDeConfianza.ConReservas)
                {
                    puntajeConfianzaTotal -= 0.2F;
                }
            }
            return puntajeConfianzaTotal / cantidadDeMiembros;
        }
    }
}