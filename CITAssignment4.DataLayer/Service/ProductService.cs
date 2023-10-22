using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;

namespace CITAssignment4.DataLayer.Service;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> GetProductById(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null)
        {
            // Handle the case when the product is not found
            throw new Exception($"Product with id {id} not found.");
        }
        // Implement additional business logic here if needed
        return product;
    }

    public async Task<List<Product>> GetProductsBySubstring(string substring)
    {
        var products = await _productRepository.GetAll();
        return products.Where(p => p.Name.Contains(substring)).ToList();
    }

    public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
    {
        var products = await _productRepository.GetAll();
        return products.Where(p => p.CategoryId == categoryId).ToList();
    }
}