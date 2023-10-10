namespace ServicioCalculadorGradoDeConfianza.Domain.Confianza
{
    public class GradoDeConfianzaConverter
    {
        public string Convertir(GradoDeConfianza gradoDeConfianza) {

            string gradoDeConfianzaADevolver = " "; 
            
            switch(gradoDeConfianza) {
                    
                case GradoDeConfianza.NoConfiable: 
                    gradoDeConfianzaADevolver = "No confiable"; 
                    break; 

                case GradoDeConfianza.ConReservas: 
                    gradoDeConfianzaADevolver = "Con reservas"; 
                    break; 
                case GradoDeConfianza.ConfiableNivel1: 
                    gradoDeConfianzaADevolver = "Confiable Nivel 1"; 
                    break; 
                case GradoDeConfianza.ConfiableNivel2: 
                    gradoDeConfianzaADevolver = "Confiable Nivel 2"; 
                    break; 
            
             }
            return gradoDeConfianzaADevolver; 

        }
    }
}
