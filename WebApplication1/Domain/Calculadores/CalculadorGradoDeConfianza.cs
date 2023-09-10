
using ServicioCalculadorGradoDeConfianza.Domain.Confianza;

namespace ServicioCalculadorGradoDeConfianza.Domain.Calculadores
{
    public class CalculadorGradoDeConfianza
    {
        public GradoDeConfianza CalcularGradoDeConfianza(float puntos)
        {

            GradoDeConfianza gradoDeConfianzaObtenido = new();

            if (puntos < 2)
            {
                gradoDeConfianzaObtenido = GradoDeConfianza.NoConfiable;
            }
            else if (puntos >= 2 && puntos <= 3)
            {

                gradoDeConfianzaObtenido = GradoDeConfianza.ConReservas;
            }

            else if (puntos >= 3 && puntos <= 5)
            {
                gradoDeConfianzaObtenido = GradoDeConfianza.ConfiableNivel1;
            }

            else if (puntos > 5)
            {
                gradoDeConfianzaObtenido = GradoDeConfianza.ConfiableNivel2;
            }

            return gradoDeConfianzaObtenido;
        }
    }
}

