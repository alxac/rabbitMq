namespace Rabbit.Model.Entities
{
    public class RabbitMensagem
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public string? Remetente { get; set; }
        public string? Assunto { get; set; }
        public string? Body { get; set; }
    }
}
