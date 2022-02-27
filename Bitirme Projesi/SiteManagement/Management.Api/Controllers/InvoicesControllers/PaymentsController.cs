using EventBus.Messages.Commons;
using EventBus.Messages.Events.Payments;
using Management.Application.Features.Commands.Invoices.Bills.AddPayment;
using Management.Application.Features.Queries.Invoices.GetPayment.GetPaymentByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Management.Api.Controllers.InvoicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost]
        [Authorize(Roles = "Resident")]
        public async Task<IActionResult> AddPayment(AddPaymentCommand paymentCommand)
        {
            //to pay bill
            var messageList = await _mediator.Send(new AddPaymentCommand());
            return Ok(messageList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            //payment which are paid according to id
            var result = await _mediator.Send(new GetPaymentByUserIdQuery(id));

            return Ok(result);
        }
    }
}

