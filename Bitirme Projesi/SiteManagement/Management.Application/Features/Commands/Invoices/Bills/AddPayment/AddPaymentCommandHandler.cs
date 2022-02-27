using AutoMapper;
using EventBus.Messages.Commons;
using EventBus.Messages.Events.Payments;
using EventBus.Messages.Models;
using Management.Application.Contracts.Persistance.Repositories.Invoices;
using Management.Domain.Entities.Invoices;
using MediatR;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Invoices.Bills.AddPayment
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IConnection _connection;

        public AddPaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
        }

        public async Task<int> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            InpaymentModel inpaymentModel = new()
            {
                UserId = request.UserId,
                Amount = request.Amount,
                CardNumber = request.CardNumber,
                BillId = request.BillId,
                CardPassword = request.CardPassword,
            };
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: EventBusConstants.PaymentCreateQueue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var payInfo = JsonSerializer.Serialize(inpaymentModel);

                var body = Encoding.UTF8.GetBytes(payInfo);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: EventBusConstants.PaymentCreateQueue,
                    basicProperties: null,
                    body: body
                );
            }

           var paymentToAdd = _mapper.Map<Payment>(request);
           paymentToAdd.CreatedDate = DateTime.Now;
           await _paymentRepository.AddAsync(paymentToAdd);
           return paymentToAdd.Id;

        }
    }
}
