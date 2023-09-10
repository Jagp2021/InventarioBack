namespace Inventario.Core.Dtos
{
    public class ResponseDto
    {
        public string? Mensaje { get; set; }
        public object? Data { get; set; }
        public int Codigo { get; set; }
        public bool Estado { get; set; }
    }
}
