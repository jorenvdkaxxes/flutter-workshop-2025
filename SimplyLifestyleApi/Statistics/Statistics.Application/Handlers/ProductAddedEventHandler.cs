using Common.Application;
using Common.Domain;
using Statistics.Domain;

namespace Statistics.Application;

public class ProductAddedEventHandler : IEventHandler<ProductAddedEvent>
{
    private readonly IStatisticsDomainRepository statisticsRepository;

    public ProductAddedEventHandler(IStatisticsDomainRepository statisticsRepository) 
        => this.statisticsRepository = statisticsRepository;

    public Task Handle(ProductAddedEvent domainEvent)
        => statisticsRepository.IncrementProducts();
}