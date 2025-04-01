using Common.Domain;
using Common.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CustomerManagement.Infrastructure.Persistence;

public class CustomerDbInitializer : DbInitializer
{
    public CustomerDbInitializer(CustomerDbContext db, ILogger<CustomerDbInitializer> logger)
        : base(db, logger, new List<IInitialData>()) { }
}