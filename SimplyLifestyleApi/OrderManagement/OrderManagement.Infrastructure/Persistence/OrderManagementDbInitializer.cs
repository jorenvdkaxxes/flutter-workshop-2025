using Common.Domain;
using Common.Infrastructure;
using Microsoft.Extensions.Logging;

namespace OrderManagement.Infrastructure;

internal class OrderManagementDbInitializer : DbInitializer
{
    public OrderManagementDbInitializer(
        OrderManagementDbContext db,
        ILogger<OrderManagementDbInitializer> logger)
        : base(db, logger, new List<IInitialData>())
    {
    }
    public override int Index => 4;
}