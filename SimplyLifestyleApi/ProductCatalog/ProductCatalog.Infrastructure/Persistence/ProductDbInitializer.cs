using Common.Domain;
using Common.Infrastructure;
using Microsoft.Extensions.Logging;
using ProductCatalog.Domain;

namespace ProductCatalog.Infrastructure;

internal class ProductDbInitializer : DbInitializer
{
    public ProductDbInitializer(ProductDbContext db, ILogger<ProductDbInitializer> logger) 
        : base(db, logger, new List<IInitialData> { new ProductData() }) {}
}
