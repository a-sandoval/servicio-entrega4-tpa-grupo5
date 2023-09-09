using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioCalculadorGradoDeConfianza.Domain.calculadores;
using ServicioCalculadorGradoDeConfianza.DTOs.Request.Request;

[TestClass]
public class CalcularPuntajeConfianzaTest{

    [TestMethod]
    public void IncidenteEsAperturaFraudulenta(){

        CalculadorPuntajeConfianzaDeUsuario calculador = new CalculadorPuntajeConfianzaDeUsuario();
        Incidente incidente = new Incidente();
        incidente.FechaApertura = new DateTime(2023, 1, 1, 0, 0, 0);
        incidente.FechaCierre = new DateTime(2023, 1, 1, 0, 1, 0); //Diferencia de 1 minuto

        Assert.IsTrue(calculador.EsAperturaFraudulenta(incidente)); 
    }
}