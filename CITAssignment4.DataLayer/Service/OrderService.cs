using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Service.Interfaces;

namespace CITAssignment4.DataLayer.Service;

public class OrderService : IOrderService
{
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<OrderDetails> _orderDetailsRepository;

    public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<OrderDetails> orderDetailsRepository)
    {
        _orderRepository = orderRepository;
        _orderDetailsRepository = orderDetailsRepository;
    }

    public async Task<Order> GetCompleteOrderById(int id)
    {
        var order = await _orderRepository.GetById(id);
        if (order == null)
        {
            // Handle the case when the order is not found
            throw new Exception($"Order with id {id} not found.");
        }
        // Implement additional business logic here if needed
        return order;
    }

    public async Task<List<Order>> GetOrdersByShippingName(string shippingName)
    {
        var orders = await _orderRepository.GetAll();
        return orders.Where(o => o.ShipName == shippingName).ToList();
    }

    public async Task<List<Order>> GetAllOrders()
    {
        return await _orderRepository.GetAll();
    }

    public async Task<List<OrderDetails>> GetDetailsByOrderId(int orderId)
    {
        var orderDetails = await _orderDetailsRepository.GetAll();
        return orderDetails.Where(od => od.OrderId == orderId).ToList();
    }


    public async Task<List<OrderDetails>> GetDetailsByProductId(int productId)
    {
        var orderDetails = await _orderDetailsRepository.GetAll();
        return orderDetails.Where(od => od.ProductId == productId).ToList();
    }
}