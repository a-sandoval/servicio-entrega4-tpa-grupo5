using Microsoft.AspNetCore.Mvc;
using ServicioCalculadorGradoDeConfianza.DTOs.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Response;

namespace ServicioCalculadorGradoDeConfianza.Domain.calculadores
{
    public class CalculadorPuntajeConfianzaDeUsuario
    {

        public float CalcularPuntajeConfianza(Usuario usuario, List<Incidente> incidentes)
        {
            bool accionLegitimaSemanal = false;
            float puntajeSemanal = 0;
            float restarFraudulento = 0.2F;
            float aumentarPuntaje = 0.5F;


            foreach (var incidente in incidentes)
            {

                if (EsAperturaFraudulenta(incidente) || EsCierreFraudulento(incidente, incidentes))
                {
                    puntajeSemanal = puntajeSemanal - restarFraudulento;
                }
                else
                {
                    accionLegitimaSemanal = true;
                }
            }

            if (accionLegitimaSemanal) { puntajeSemanal += aumentarPuntaje; }

            return puntajeSemanal;
        }

        public bool EsAperturaFraudulenta(Incidente incidente)
        {

            DateTime fecha1 = incidente.FechaApertura;
            DateTime fecha2 = incidente.FechaCierre;

            TimeSpan diferencia = fecha2 - fecha1;

            return diferencia.TotalMinutes < 3;
        }


        public bool EsCierreFraudulento(Incidente incidenteCerrado, List<Incidente> incidentes)
        {
            int IDServicioAfectado = incidenteCerrado.ServicioAfectado.Id;

            Func<Incidente, bool> filtro = incidente => incidente.ServicioAfectado.Id == IDServicioAfectado &&
                                                        (incidente.FechaApertura - incidenteCerrado.FechaCierre).TotalMinutes <= 3;

            return incidentes.Any(filtro);
        }

   
    }
}





