namespace poc
{
    public class Incidente{
        int id {get; set;}
        DateTime fechaApertura;
        Usuario usuarioReportador;
        DateTime fechaCierre;
        Usuario usuarioAnalizador;
        PrestacionDeServicio servicioAfectado;
    }
}