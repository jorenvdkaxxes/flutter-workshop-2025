using MediatR;
using OrderManagement.Domain;

namespace OrderManagement.Application;

public class CreateOrderCommand : OrderCommand, IRequest<CreateOrderResponse>
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrderDomainRepository _orderRepository;
        private readonly IOrderFactory _orderFactory;

        public CreateOrderCommandHandler(
            IOrderDomainRepository orderRepository,
            IOrderFactory orderFactory)
        {
            _orderRepository = orderRepository;
            _orderFactory = orderFactory;
        }

        public async Task<CreateOrderResponse> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = _orderFactory
                .WithOrderDate(request.OrderDate)
                .WithCustomerId(request.CustomerId)
                .Build();

            request.OrderItems.ForEach(orderItem =>
            {
                order.AddOrderItem(orderItem.ProductId, orderItem.Quantity);
            });

            await _orderRepository.Save(order, cancellationToken);

            return new CreateOrderResponse(order.Id);
        }
    }
}