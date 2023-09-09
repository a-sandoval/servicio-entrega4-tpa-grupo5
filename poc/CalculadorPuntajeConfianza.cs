namespace poc
{
    public class CalculadorPuntajeConfianza{

        Boolean esAperturaFraudulenta(Incidente incidente){
            
            DateTime fecha1 = Incidente.fechaInicio; 
            DateTime fecha2 = Incidente.fechaCierre;

            TimeSpan diferencia = fecha2 - fecha1;

            return (diferencia.TotalMinutes < 3);
        }

        Boolean esCierreFraudulento(Incidente incidente, List<Incidente> incidentes){

            for (incidente1 in incidentes)
            {
                int servicioAfectado = incidente.servicioAfectado;

                for (incidente2 in incidentes where incidente.servicioAfectado = servicioAfectado)
                {
                    return (incidente2.fechaInicio - incidente1.fechaCierre < 3)
                }
            }
            
        }
    }
}




        
