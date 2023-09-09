
namespace poc
{
    public class calcularGradoConfianza{

        GradoDeConfianza calcularGradoDeConfianza(int puntos){
            if(puntos< 2){
                return GradoDeConfianza.NoConfiable;
            }
            if(puntos>=2 && puntos<=3){
                return GradoDeConfianza.ConReservas;
            }

            if(puntos>=3 && puntos<=5){
                return GradoDeConfianza.ConfiableNivel1;
            }
            
            if(puntoa > 5){
                return GradoDeConfianza.ConfiableNivel2;
            }
        }
    }
}