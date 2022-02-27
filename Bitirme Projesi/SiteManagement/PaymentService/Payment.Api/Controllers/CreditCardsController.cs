using EventBus.Messages.Commons;
using EventBus.Messages.Events.Payments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Payment.Application.Contracts.Persistance.Repositories.Payments;
using Payment.Application.Contracts.Persistance.Repositories.Payments.Helper;
using Payment.Application.Features.Commands.Payments.CreditCards.AddCreditCard;
using Payment.Application.Features.Queries.Payments.CreditCards.GetCreditCardList.GetAllCreditCard;
using Payment.Application.Features.Queries.Payments.CreditCards.GetCreditCardList.GetCreditCardByNumber;
using Payment.Domain.Entities.CreditCards;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMediator _mediator;
        private readonly ICreditCardCheckHelper _creditCardCheckHelper;
        private readonly IConnection _connection;


        public CreditCardsController(IMediator mediator, ICreditCardRepository creditCardRepository, ICreditCardCheckHelper creditCardCheckHelper)
        {
            _mediator = mediator;
            _creditCardRepository = creditCardRepository;
            _creditCardCheckHelper = creditCardCheckHelper;


            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "test",
                Password = "test"
            };
            _connection = factory.CreateConnection();

        }

        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetCreditCardByNumber(string cardNumber)
        {
            var result = await _mediator.Send(new GetCreditCardByNumberQuery(cardNumber));
            if (result != null)
                return Ok(result);
            return BadRequest("Kayıt bulunamadı.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCreditCard()
        {
            var result = await _mediator.Send(new GetCreditCardListQuery());
            if (result != null)
                return Ok(result);
            return BadRequest("Kayıt bulunamadı.");
        }
        [HttpPost]
        public async Task<IActionResult> AddCreditCard(AddCreditCardCommand addCreditCardCommand)
        {
            var signUpResult = await _mediator.Send(addCreditCardCommand);
            return Ok();
        }
        [HttpGet("payment")]
        public async Task<IActionResult> Pay()
        {
           
            
            #region Rabbitmq
            using (var channel = _connection.CreateModel())
            {
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(EventBusConstants.PaymentCreateQueue, true, consumer);
                consumer.Received += (sender, e) =>
                {


                    var jsonString = Encoding.UTF8.GetString(e.Body.ToArray());
                    var cardInfo = JsonConvert.DeserializeObject<CreditCard>(jsonString);
                    //Information from payment with rabbitmq is checked by an helper class
                    _creditCardCheckHelper.CheckCardForPayment(cardInfo);

                };

                #endregion
                return Ok();




            }


        }
    }
}



