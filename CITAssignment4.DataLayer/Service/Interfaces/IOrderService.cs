using CITAssignment4.DataLayer.Domain;

namespace CITAssignment4.DataLayer.Service.Interfaces;

public interface IOrderService
{
    Task<Order> GetCompleteOrderById(int id);
    Task<List<Order>> GetOrdersByShippingName(string shippingName);
    Task<List<Order>> GetAllOrders();
    Task<List<OrderDetails>> GetDetailsByOrderId(int orderId);
    Task<List<OrderDetails>> GetDetailsByProductId(int productId);
}