using MediatR;

public class GetAllProductsQuery : EntityCommand, IRequest<IEnumerable<ProductResponse>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly IProductQueryRepository productRepository;

        public GetAllProductsQueryHandler(IProductQueryRepository productRepository)
            => this.productRepository = productRepository;
        
        public async Task<IEnumerable<ProductResponse>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
            => await productRepository.GetAll(
                cancellationToken);
    }
}
