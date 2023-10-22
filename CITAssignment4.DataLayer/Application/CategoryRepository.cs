using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CITAssignment4.DataLayer.Application;

public class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(CITDbContext context, ILogger<CategoryRepository> logger) : base(context, logger)
    {
    }
}