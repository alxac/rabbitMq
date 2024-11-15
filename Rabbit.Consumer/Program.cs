using Rabbit.Model.Entities;
using Rabbit.Repositories;

var messageQueueService = new MessageQueueService<RabbitMensagem>();
messageQueueService.ConsumerMessage("mensagem");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
