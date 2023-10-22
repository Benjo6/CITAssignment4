using CITAssignment4.DataLayer.Domain;

namespace CITAssignment4.DataLayer.Service;

public interface IProductService
{
    Task<Product> GetProductById(int id);
    Task<List<Product>> GetProductsBySubstring(string substring);
    Task<List<Product>> GetProductsByCategoryId(int categoryId);
}