using CITAssignment4.DataLayer.Application.Interfaces;
using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Service.Interfaces;

namespace CITAssignment4.DataLayer.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _repository.GetAll();
    }

    public async Task<Category> AddCategory(string name, string description)
    {
        var category = new Category { Name = name, Description = description };
        return await _repository.Add(category);
    }

    public async Task<bool> UpdateCategory(int id, string name, string description)
    {
        var category = await _repository.GetById(id);
        if (category == null)
        {
            return false;
        }

        category.Name = name;
        category.Description = description;

        return await _repository.Update(category);
    }

    public async Task<bool> DeleteCategory(int id)
    {
        if (await _repository.GetById(id) == null)
        {
            return false;
        }
        return await _repository.Delete(id);
    }
}