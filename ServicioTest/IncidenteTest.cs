using ServicioCalculadorGradoDeConfianza.Domain.calculadores;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioTest
{
    [TestClass]
    public class IncidenteTest
    {
        [TestMethod]
       
        public void IncidenteEsAperturaFraudulenta()
         {

            CalculadorPuntajeConfianzaDeUsuario calculador = new CalculadorPuntajeConfianzaDeUsuario();
            Incidente incidente = new Incidente
            {
                FechaApertura = new DateTime(2023, 1, 1, 0, 0, 0),
                FechaCierre = new DateTime(2023, 1, 1, 0, 1, 0),
                UsuarioReportador = new Usuario(),
                UsuarioAnalizador = new Usuario()//Diferencia de 1 minuto
            };

            incidente.UsuarioReportador.Id = 0; 
            incidente.UsuarioAnalizador.Id = 2; 

            Assert.IsTrue(calculador.EsAperturaFraudulenta(incidente.UsuarioReportador, incidente));
        }

        [TestMethod]

        public void IncidenteEsCierreFraudulento() {
            
            CalculadorPuntajeConfianzaDeUsuario calculador = new CalculadorPuntajeConfianzaDeUsuario();
            Incidente incidente = new Incidente
            {
                FechaApertura = new DateTime(2023, 1, 1, 0, 0, 0),
                FechaCierre = new DateTime(2023, 1, 1, 0, 1, 0), 
                ServicioAfectado = new PrestacionDeServicio(), 
                UsuarioReportador = new Usuario(), 
                UsuarioAnalizador = new Usuario(),

                
            };
            incidente.ServicioAfectado.Id = 2; 
            incidente.UsuarioReportador.Id = 2; 
            incidente.UsuarioAnalizador.Id = 3; 

            Incidente otroIncidenteSobreMismoServicio = new Incidente {
                FechaApertura = new DateTime(2023,1,1,0,2,0), 
                FechaCierre = new DateTime(2023,1,2,0,0,0),
                ServicioAfectado = new PrestacionDeServicio(),
            }; 
            otroIncidenteSobreMismoServicio.ServicioAfectado.Id = 2; 

            List<Incidente> incidentesSimilares = new List<Incidente>
            {
                otroIncidenteSobreMismoServicio
            }; 


            Assert.IsTrue(calculador.EsCierreFraudulento(incidente.UsuarioAnalizador, incidente, incidentesSimilares));




        }
    }
}