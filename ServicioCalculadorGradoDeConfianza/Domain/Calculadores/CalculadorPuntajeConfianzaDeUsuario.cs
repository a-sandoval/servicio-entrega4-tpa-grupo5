using Microsoft.AspNetCore.Mvc;
using ServicioCalculadorGradoDeConfianza.Domain.Calculadores;
using ServicioCalculadorGradoDeConfianza.Domain.Confianza;
using ServicioCalculadorGradoDeConfianza.DTOs.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;
using ServicioCalculadorGradoDeConfianza.DTOs.Response;

namespace ServicioCalculadorGradoDeConfianza.Domain.calculadores
{
    public class CalculadorPuntajeConfianzaDeUsuario
    {   
        private readonly CalculadorGradoDeConfianza calculadorGradoDeConfianza; 

        public CalculadorPuntajeConfianzaDeUsuario(CalculadorGradoDeConfianza calculadorGradoDeConfianza) {
            this.calculadorGradoDeConfianza = calculadorGradoDeConfianza; 
        }

        public CalculadorPuntajeConfianzaDeUsuario()
        {
        }

        public GradoDeConfianzaResponseUsuario ObtenerGradoDeConfianzaResponse(UsuarioRequest usuarioRequest) {
            
            float puntajeConfianza = CalcularPuntajeConfianza(usuarioRequest.Usuario, usuarioRequest.Incidentes); 
            
            GradoDeConfianza gradoConfianza = calculadorGradoDeConfianza.CalcularGradoDeConfianza(puntajeConfianza); 

            GradoDeConfianzaConverter converter = new(); 

            return new GradoDeConfianzaResponseUsuario(usuarioRequest.Usuario, puntajeConfianza, converter.Convertir(gradoConfianza)); 

        }

        public float CalcularPuntajeConfianza(Usuario usuario, List<Incidente> incidentes)
        {
            bool accionLegitimaSemanal = false;
            float puntajeSemanal = usuario.PuntosDeConfianza; 
            float restarFraudulento = 0.2F;
            float aumentarPuntaje = 0.5F;

            List<Incidente> incidentesDelUsuario = incidentes.Where(i => i.UsuarioReportador.Id == usuario.Id || i.UsuarioAnalizador.Id == usuario.Id).ToList();

            foreach (var incidente in incidentesDelUsuario)
            {

                if (EsAperturaFraudulenta(usuario, incidente) || EsCierreFraudulento(usuario, incidente, incidentes))
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

        public bool EsAperturaFraudulenta(Usuario usuario, Incidente incidente)
        {   
            if(usuario.Id == incidente.UsuarioReportador.Id)
            {
                DateTime fecha1 = incidente.FechaApertura;
                DateTime fecha2 = incidente.FechaCierre;

                TimeSpan diferencia = fecha2 - fecha1;

                return diferencia.TotalMinutes < 3;


            }

            return false; 
            
        }


        public bool EsCierreFraudulento(Usuario usuario, Incidente incidenteCerrado, List<Incidente> incidentes)
        {
            List<Incidente> incidentesPosteriores = incidentes.Where(i => i.FechaApertura > incidenteCerrado.FechaCierre).ToList();


            if (usuario.Id == incidenteCerrado.UsuarioAnalizador.Id && incidentesPosteriores.Count != 0)
            {
                int IDServicioAfectado = incidenteCerrado.ServicioAfectado.Id;

                Func<Incidente, bool> filtro = incidente => incidente.ServicioAfectado.Id == IDServicioAfectado &&
                                                            (incidente.FechaApertura - incidenteCerrado.FechaCierre).TotalMinutes <= 3;

                return incidentes.Any(filtro);

            }

            return false;

        }


    }
}





