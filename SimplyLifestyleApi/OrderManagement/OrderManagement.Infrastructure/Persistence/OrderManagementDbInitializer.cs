using Common.Domain;
using Common.Infrastructure;

namespace OrderManagement.Infrastructure;

internal class OrderManagementDbInitializer : DbInitializer
{
    public OrderManagementDbInitializer(
        OrderManagementDbContext db)
        : base(db, new List<IInitialData>())
    {
    }
}