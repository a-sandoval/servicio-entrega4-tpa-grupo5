namespace poc
{
    public class CalculadorPuntajeConfianza{

        float calcularPuntajeConfianza(Usuario usuario, List<Incidente> incidentes)
        {
            Bool accionLegitimaSemanal = false;
            float puntajeSemanal = 0;

            for(incidente in incidentes){

                if (self.esAperturaFradulenta(incidente) || self.esCierreFraudulento(incidente))
                {
                    puntajeSemanal -= 0,2;
                }
                else{
                    accionLegitimaSemanal = true;
                }
            }

            if(accionLegitimaSemanal){puntajeSemanal += 0,5}

            return puntajeSemanal;
        }

        Boolean esAperturaFraudulenta(Incidente incidente){
            
            DateTime fecha1 = Incidente.fechaInicio; 
            DateTime fecha2 = Incidente.fechaCierre;

            TimeSpan diferencia = fecha2 - fecha1;

            return (diferencia.TotalMinutes < 3);
        }
        

        bool esCierreFraudulento(Incidente incidenteCerrado, List<Incidente> incidentes)
            {
                int IDServicioAfectado = incidenteCerrado.servicioAfectado;

                Func<Incidente, bool> filtro = incidente => incidente.servicioAfectado == IDServicioAfectado &&
                                                            (incidente.fechaInicio - incidenteCerrado.fechaCierre).TotalMinutes =< 3;

                return incidentes.Any(filtro);
            }
    }
}




        
