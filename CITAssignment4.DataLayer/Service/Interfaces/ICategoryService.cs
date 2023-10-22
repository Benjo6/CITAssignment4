using CITAssignment4.DataLayer.Domain;

namespace CITAssignment4.DataLayer.Service.Interfaces;

public interface ICategoryService
{
    Task<Category> GetCategoryById(int id);
    Task<List<Category>> GetAllCategories();
    Task<Category> AddCategory(string name, string description);
    Task<bool> UpdateCategory(int id, string name, string description);
    Task<bool> DeleteCategory(int id);
}