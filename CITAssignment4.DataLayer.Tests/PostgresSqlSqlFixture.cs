using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

public class PostgresSqlSqlFixture  : IAsyncLifetime
{
    private class TestDbContextFactory : IDbContextFactory<CITDbContext>
    {
        private readonly DbContextOptionsBuilder<CITDbContext> _dbContextOptionsBuilder;
        public TestDbContextFactory(string connection)
        {
            _dbContextOptionsBuilder = new DbContextOptionsBuilder<CITDbContext>().UseNpgsql(connection, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(5);
                optionsBuilder.CommandTimeout(500);
                optionsBuilder.MigrationsAssembly(typeof(CITDbContext).Assembly.FullName);
            }).UseSnakeCaseNamingConvention().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
        } 
        public CITDbContext CreateDbContext()
        {
            return new CITDbContext(_dbContextOptionsBuilder.Options);
        }
    }
    private PostgreSqlContainer PostgreSql { get; }
    public IDbContextFactory<CITDbContext> ContextFactory { get; private set; }

    public PostgresSqlSqlFixture()
    {
        this.PostgreSql = new PostgreSqlBuilder().Build();
    }

    public async Task Seed(IEnumerable<Order> orders, IEnumerable<OrderDetails> orderDetails, IEnumerable<Product> products, IEnumerable<Category> categories)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        context.Orders.AddRange(orders);
        context.OrderDetails.AddRange(orderDetails);
        context.Products.AddRange(products);
        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();
    }

    public async Task Clean()
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        context.Orders.RemoveRange(context.Orders);
        context.OrderDetails.RemoveRange(context.OrderDetails);
        context.Products.RemoveRange(context.Products);
        context.Categories.RemoveRange(context.Categories);
        await context.SaveChangesAsync();
    }


    public async Task InitializeAsync()
    {
        await this.PostgreSql.StartAsync()
            .ConfigureAwait(false);

        ContextFactory = new TestDbContextFactory(PostgreSql.GetConnectionString());
        await using var context = await ContextFactory.CreateDbContextAsync();
        await context.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await this.PostgreSql.DisposeAsync()
            .ConfigureAwait(false);
    }
}