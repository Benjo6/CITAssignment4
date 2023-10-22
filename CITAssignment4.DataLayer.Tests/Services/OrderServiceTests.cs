using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Service;
using NSubstitute;

namespace CITAssignment4.DataLayer.Tests.Services;

public class OrderServiceTests
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<OrderDetails> _orderDetailsRepository;
    private readonly OrderService _service;
    public OrderServiceTests()
    {
        _orderRepository = Substitute.For<IGenericRepository<Order>>();
        _orderDetailsRepository = Substitute.For<IGenericRepository<OrderDetails>>();
        _service = new OrderService(_orderRepository, _orderDetailsRepository);

        // Dummy data for GetCompleteOrderById
        _orderRepository.GetById(10248).Returns(new Order
        {
            Id = 10248,
            OrderDate = new DateTime(2023, 1, 15),
            RequireDate = new DateTime(2023, 1, 20),
            ShipName = "John Doe",
            ShipCity = "New York",
            OrderDetails = new List<OrderDetails>
            { 
                new(){
                    Order = new Order
                    {
                        OrderDate = new DateTime(1996,7,4)
                    }, 
                    Product = new Product {Name = "Queso Cabrales", Category = new (){Name = "Dairy Products"}}},
                new(),
                new()
            }
        });

        // Dummy data for GetDetailsByOrderId
        _orderDetailsRepository.GetAll().Returns(new List<OrderDetails>
        {
            new()
            {
                OrderId = 10248,
                ProductId = 11,
                UnitPrice = 14,
                Quantity = 12,
                Discount = 5,
                Order = new Order
                {
                    OrderDate = new DateTime(1996,7,4)
                }, 
                Product = new Product {Name = "Queso Cabrales", Category = new (){Name = "Dairy Products"}}
            },
            new ()
            {
                ProductId = 1,
                OrderId = 10248
            },
            new ()
            {
                OrderId = 10248
            },
            new ()
            {
                ProductId = 11
            }
        });

        // Dummy data for GetAllOrders
        _orderRepository.GetAll().Returns(new List<Order>
        {
            new()
            {
                Id = 10248,
                OrderDate = new DateTime(2023, 1, 15),
                RequireDate = new DateTime(2023, 1, 20),
                ShipName = "John Doe",
                ShipCity = "New York"
            } 
        });
    }
    
    /* orders */
    [Fact]
    public void Order_Object_HasIdDatesAndOrderDetails()
    {
        var order = new Order();
        Assert.Equal(0, order.Id);
        Assert.Equal(null, order.OrderDate);
        Assert.Equal(null, order.RequireDate);
        Assert.Null(order.ShipName);
        Assert.Null(order.ShipCity);
    }

    [Fact]
    public async Task GetOrder_ValidId_ReturnsCompleteOrder()
    {
        var order = await _service.GetCompleteOrderById(10248);
        Assert.Equal(3, order.OrderDetails?.Count);
        Assert.Equal("Queso Cabrales", order.OrderDetails?.First().Product?.Name);
        Assert.Equal("Dairy Products", order.OrderDetails?.First().Product?.Category?.Name);
    }

    [Fact]
    public async Task GetOrders()
    {
        var orders = await _service.GetAllOrders();
        Assert.Equal(1, orders.Count);
    } 
    
    /* order details */
    [Fact]
    public void OrderDetails_Object_HasOrderProductUnitPriceQuantityAndDiscount()
    {
        var orderDetails = new OrderDetails();
        Assert.Equal(0, orderDetails.OrderId);
        Assert.Null(orderDetails.Order);
        Assert.Equal(0, orderDetails.ProductId);
        Assert.Null(orderDetails.Product);
        Assert.Equal(0.0, orderDetails.UnitPrice);
        Assert.Equal(0.0, orderDetails.Quantity);
        Assert.Equal(0.0, orderDetails.Discount);
    }

    [Fact]
    public async Task GetOrderDetailByOrderId_ValidId_ReturnsProductNameUnitPriceAndQuantity()
    {
        var orderDetails = await _service.GetDetailsByOrderId(10248);
        Assert.Equal(3, orderDetails.Count);
        Assert.Equal("Queso Cabrales", orderDetails.First().Product?.Name);
        Assert.Equal(14, orderDetails.First().UnitPrice);
        Assert.Equal(12, orderDetails.First().Quantity);
    }

    [Fact]
    public async Task GetOrderDetailByProductId_ValidId_ReturnsOrderDateUnitPriceAndQuantity()
    {
        var orderDetails = await _service.GetDetailsByProductId(11);
        Assert.Equal(2, orderDetails.Count);
        Assert.Equal(10248, orderDetails.First().OrderId);
        Assert.Equal("1996-07-04", orderDetails.First().Order?.OrderDate?.ToString("yyyy-MM-dd"));
        Assert.Equal(14, orderDetails.First().UnitPrice);
        Assert.Equal(12, orderDetails.First().Quantity);
    }
}