using CITAssignment4.DataLayer.Application.Interfaces;
using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CITAssignment4.DataLayer.Application;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(CITDbContext context, ILogger<OrderRepository> logger) : base(context, logger)
    {
    }
}