using CITAssignment4.DataLayer.Application.Interfaces;
using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CITAssignment4.DataLayer.Application;

public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(CITDbContext context, ILogger<OrderDetailsRepository> logger) : base(context, logger)
    {
    }
}