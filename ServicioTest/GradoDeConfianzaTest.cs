using ServicioCalculadorGradoDeConfianza.Domain.calculadores;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

namespace ServicioTest
{
    [TestClass]
    public class GradoDeConfianzaTest
    {
        [TestMethod]
       
        public void PuntajeDeConfianza(){

            CalculadorPuntajeConfianzaDeUsuario calculador = new ();

            Usuario usuario = new Usuario();
            Usuario otroUsuario = new Usuario();
            Usuario buenUsuario = new Usuario(); 

            otroUsuario.Id = 2; 
            usuario.Id = 0;
            buenUsuario.Id = 3;
            usuario.PuntosDeConfianza = 5;
            otroUsuario.PuntosDeConfianza = 5;
            buenUsuario.PuntosDeConfianza = 5; 

            Incidente incidente = new Incidente();
            incidente.ServicioAfectado = new PrestacionDeServicio();
            incidente.ServicioAfectado.Id = 2; 
            incidente.UsuarioReportador = otroUsuario;
            incidente.UsuarioAnalizador = usuario;
            incidente.Id = 1;
            incidente.FechaApertura = new DateTime(2023, 1, 1, 0, 0, 0);
            incidente.FechaCierre = new DateTime(2023, 1, 1, 0, 5, 0);
 

            Incidente otroIncidente = new Incidente();
            otroIncidente.ServicioAfectado = new PrestacionDeServicio();
            otroIncidente.ServicioAfectado.Id = 2;
            otroIncidente.UsuarioReportador = otroUsuario;
            otroIncidente.UsuarioAnalizador = usuario;
            otroIncidente.Id = 2;
            otroIncidente.FechaApertura = new DateTime(2023, 1, 1, 0, 6, 0); 
            otroIncidente.FechaCierre = new DateTime(2023, 1, 2, 0, 1, 0);

            List<Incidente> incidentes = new List<Incidente> { incidente, otroIncidente };


        Assert.AreEqual(5.3,Math.Round(calculador.CalcularPuntajeConfianza(usuario, incidentes),2));
        Assert.AreEqual(5.5,calculador.CalcularPuntajeConfianza(otroUsuario, incidentes));
        Assert.AreEqual(5,calculador.CalcularPuntajeConfianza(buenUsuario, incidentes));


        }
    }
}