using Common.Application;
using MediatR;

namespace OrderManagement.Application;

public class GetAllOrdersQuery : EntityCommand, IRequest<IEnumerable<OrderResponse>>
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderQueryRepository productRepository;

        public GetAllOrdersQueryHandler(IOrderQueryRepository productRepository)
            => this.productRepository = productRepository;

        public async Task<IEnumerable<OrderResponse>> Handle(
            GetAllOrdersQuery request,
            CancellationToken cancellationToken)
            => await productRepository.GetAll(
                cancellationToken);
    }
}
