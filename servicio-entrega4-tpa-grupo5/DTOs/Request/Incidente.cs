namespace ServicioCalculadorGradoDeConfianza.DTOs.Request.Request
{
    public class Incidente
    {
        public long Id { get; set; }
        public DateTime FechaApertura { get; set; }
        public Usuario UsuarioReportador { get; set; }
        public DateTime FechaCierre { get; set; }
        public Usuario UsuarioAnalizador { get; set; }
        public PrestacionDeServicio ServicioAfectado { get; set; }
    }
}