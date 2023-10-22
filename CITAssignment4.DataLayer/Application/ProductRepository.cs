using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CITAssignment4.DataLayer.Application;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(CITDbContext context, ILogger<ProductRepository> logger) : base(context, logger)
    {
    }
}