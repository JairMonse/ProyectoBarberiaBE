namespace Shared
{
    public class Respuesta
    {

        public bool Estado { get; set; }
        public string? Message { get; set; }

        public Respuesta(bool Estado, string Message)
        {
            this.Estado = Estado;
            this.Message = Message;
        }

    }
}