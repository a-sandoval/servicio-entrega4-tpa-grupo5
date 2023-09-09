using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class calcularPuntajeConfianzaTest{

    [TestMethod]
    public void incidenteEsAperturaFraudulenta(){

        CalculadorPuntajeConfianza calculador = new CalculadorPuntajeConfianza();
        Incidente incidente = new Incidente();
        incidente.fechaInicio = new DateTime(2023, 1, 1, 0, 0, 0);
        incidente.fechaCierre = new DateTime(2023, 1, 1, 0, 1, 0); //Diferencia de 1 minuto

        Assert.IsTrue(calculador.esAperturaFradulenta(incidente)); 
    }
}