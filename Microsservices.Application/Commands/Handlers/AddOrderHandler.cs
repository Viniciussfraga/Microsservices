﻿using MediatR;
using Microsservices.Core.Repositories;
using Microsservices.Infra.MessageBus;

namespace Microsservices.Application.Commands.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrder, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBusClient _messageBus;
        public AddOrderHandler(IOrderRepository orderRepository, IMessageBusClient messageBus)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
        }
        public async Task<Guid> Handle(AddOrder request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();

            await _orderRepository.AddAsync(order);

            foreach(var @event in order.Events)
            {
                var routingKey = @event.GetType().Name.ToDashCase();
                _messageBus.Publish(@event, routingKey, "order-service");
            }

            return order.Id;
        }
    }
}
