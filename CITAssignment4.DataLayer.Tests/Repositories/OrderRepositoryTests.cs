using AutoFixture;
using AutoFixture.Xunit2;
using CITAssignment4.DataLayer.Application;
using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Infrastructure;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

public class OrderRepositoryTests : IClassFixture<PostgresSqlSqlFixture>, IDisposable, IAsyncLifetime
{
    private readonly PostgresSqlSqlFixture _fixture;
    private CITDbContext _context;
    private OrderRepository _repository;

    public OrderRepositoryTests(PostgresSqlSqlFixture fixture)
    {
        _fixture = fixture;
        _context = _fixture.ContextFactory.CreateDbContext();
        _repository = new OrderRepository(_context, Substitute.For<ILogger<OrderRepository>>());   
    }

    [Theory]
    [AutoDataWithoutRecursion]
    public async Task GetById_OrderId_ReturnsOrder(Order order)
    {
        // Arrange 
        await _repository.Add(order);

        // Act
        var orderById = await _repository.GetById(order.Id);

        // Test
        orderById.Should().NotBeNull();
        orderById.Should().BeEquivalentTo(order);
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        await _fixture.Clean();
    }
}

public class AutoDataWithoutRecursionAttribute : AutoDataAttribute
{
    public AutoDataWithoutRecursionAttribute() : base(() => 
    {
        var fixture = new Fixture();
        fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        return fixture;
    })
    {
    }
}
