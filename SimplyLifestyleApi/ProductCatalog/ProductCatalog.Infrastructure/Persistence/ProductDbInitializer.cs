using Common.Domain;
using Common.Infrastructure;
using ProductCatalog.Domain;

namespace ProductCatalog.Infrastructure;

internal class ProductDbInitializer : DbInitializer
{
    public ProductDbInitializer(ProductDbContext db) 
        : base(db, new List<IInitialData> { new ProductData() }) {}
}
