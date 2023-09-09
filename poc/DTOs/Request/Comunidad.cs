namespace ServicioCalculadorGradoDeConfianza.DTOs.Request.Request
{
    public class Comunidad
    {
        public string GradoDeConfianza { get; set; }
        public List<Usuario> Miembros { get; set; }
        public float PuntajeConfianzaActual;



    }
}