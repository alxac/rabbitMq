using Rabbit.Model.Entities;
using Rabbit.Repositories.Interfaces;

namespace Rabbit.Repositories
{
    public class RabbitMensagemRepository : IRabbitMensagemRepository
    {
        public void SendMensagem(RabbitMensagem mensagem)
        {
            var messageQueueService = new MessageQueueService<RabbitMensagem>();
            messageQueueService.PublishMessage("mensagem", mensagem);
        }
    }
}
