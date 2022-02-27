using EventBus.Messages.Commons;
using EventBus.Messages.Events;
using Management.Application.Features.Commands.Messages.AddMessage;
using Management.Application.Features.Queries.Messages.GetAllMessage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Management.Api.Controllers.MessagesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ViewMessage()
        {
            // viewing messages
            var messageList = await _mediator.Send(new GetMessageListQuery());
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"

            };
            

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("gelenmesajlar", false, false, false);
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("gelenmesajlar", false, consumer);
                consumer.Received += (sender, e) =>
                {
                    //e.Body : Kuyruktaki mesajı verir.
                    Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
                };


                return Ok(messageList);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(AddMessageCommand messageCommand)
        {
            //sending messages
            var messageToSend = await _mediator.Send(messageCommand);

            MessageCreateEvent messageCreateEvent = new MessageCreateEvent();
            messageCreateEvent.Id = messageToSend;
            messageCreateEvent.SendedTime = DateTime.Now;
            messageCreateEvent.Message = messageCommand.Text;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = factory.CreateConnection();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: EventBusConstants.MessageCreateQueue,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );
                var message = JsonSerializer.Serialize(messageCreateEvent);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: EventBusConstants.MessageCreateQueue,
                    basicProperties: null,
                    body: body
                    );
                return Ok(message);

            }
            //return Ok(messageToSend);
        }

    }
}
