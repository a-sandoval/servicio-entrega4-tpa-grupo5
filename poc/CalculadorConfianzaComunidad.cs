namespace poc{

    public class CalculadorConfianzaComunidad{


        public GradoDeConfianza calcularGradoDeConfianza(Comunidad comunidad, List<Incidente> incidentes){

            float puntajeConfianzaComunidad = this.calcularPuntajeDeConfianza(comunidad, incidentes);

            CalculadorGradoConfianza calculadoraGrado = new CalculadorGradoConfianza();

            return calculadoraGrado.calcularGradoConfianza(puntajeConfianzaComunidad);
        }


        private float calcularPuntajeDeConfianza(Comunidad comunidad, List<Incidente> incidentes){
            
            int cantidadDeMiembros = comunidad.miembros.Count;
            float puntajeConfianzaTotal = 0;

            CalculadorPuntajeConfianza calculador = new CalculadorPuntajeConfianza();
            CalculadorGradoConfianza calculadorGrado = new CalculadorGradoConfianza();
            
            foreach (Miembro miembro in comunidad.miembros){

                float puntajeMiembro = calculador.calcularPuntajeConfianza(miembro, incidentes);
                puntajeConfianzaTotal += puntajeMiembro;

                if (calculadorGrado.calcularGradoConfianza(puntajeMiembro) == GradoDeConfianza.ConReservas)
                {
                    puntajeConfianzaTotal -= 0.2;
                }
            }
            return puntajeConfianzaTotal/cantidadDeMiembros;
        }
    }
}