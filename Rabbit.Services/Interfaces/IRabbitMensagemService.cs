using Rabbit.Model.Entities;

namespace Rabbit.Services.Interfaces
{
    public interface IRabbitMensagemService
    {
        void SendMensagem(RabbitMensagem mensagem);
    }
}
