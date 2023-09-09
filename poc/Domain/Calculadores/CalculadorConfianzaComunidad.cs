using ServicioCalculadorGradoDeConfianza.Domain.Entidades;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioCalculadorGradoDeConfianza.Domain.calculadores
{

    public class CalculadorConfianzaComunidad
    {


        public GradoDeConfianza CalcularGradoDeConfianza(Comunidad comunidad, List<Incidente> incidentes)
        {

            float puntajeConfianzaComunidad = CalcularPuntajeDeConfianza(comunidad, incidentes);

            CalculadorGradoDeConfianza calculadoraGrado = new();

            return calculadoraGrado.CalcularGradoDeConfianza(puntajeConfianzaComunidad);
        }


        private float CalcularPuntajeDeConfianza(Comunidad comunidad, List<Incidente> incidentes)
        {

            int cantidadDeMiembros = comunidad.miembros.Count;
            float puntajeConfianzaTotal = 0;

            CalculadorPuntajeConfianzaDeUsuario calculador = new CalculadorPuntajeConfianzaDeUsuario();
            CalculadorGradoDeConfianza calculadorGrado = new();

            foreach (Usuario miembro in comunidad.miembros)
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