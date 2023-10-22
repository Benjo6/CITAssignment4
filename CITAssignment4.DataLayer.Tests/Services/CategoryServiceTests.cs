using CITAssignment4.DataLayer.Application.Interfaces;
using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Service;
using NSubstitute;

namespace CITAssignment4.DataLayer.Tests;

public class CategoryServiceTests
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryService _service;

    public CategoryServiceTests()
    {
        _categoryRepository = Substitute.For<ICategoryRepository>();
        _service = new CategoryService(_categoryRepository); 
        
        // Dummy data
        var categories = new List<Category>
        {
            new() { Id = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
            new() { Id = 2, Name = "Category2", Description = "Description2" },
            new() { Id = 3, Name = "Category3", Description = "Description3" },
            new() { Id = 4, Name = "Category4", Description = "Description4" },
            new() { Id = 5, Name = "Category5", Description = "Description5" },
            new() { Id = 6, Name = "Category6", Description = "Description6" },
            new() { Id = 7, Name = "Category7", Description = "Description7" },
            new() { Id = 8, Name = "Category8", Description = "Description8" }
        };

        _categoryRepository.GetAll().Returns(categories);
        _categoryRepository.GetById(1).Returns(categories.First());
        _categoryRepository.Update(categories.First()).Returns(true);
        _categoryRepository.Delete(1).Returns(true);
        _categoryRepository.Add(Arg.Any<Category>()).Returns(new Category
        {
            Id = 9,
            Name = "Test",
            Description = "CreateCategory_ValidData_CreteCategoryAndReturnsNewObject"
        });
    }
    
    [Fact]
    public void Category_Object_HasIdNameDescription()
    {
        var category = new Category();
        Assert.Equal(0, category.Id);
        Assert.Null(category.Name);
        Assert.Null(category.Description);
    }

    [Fact]
    public async Task GetAllCategories_NoArgument_ReturnsAllCategories()
    {
        var categories = await _service.GetAllCategories();
        Assert.Equal(8, categories.Count);
        Assert.Equal("Beverages", categories.First().Name);
    }

    [Fact]
    public async Task GetCategory_ValidId_ReturnsCategoryObject()
    {
        var category = await _service.GetCategoryById(1);
        Assert.Equal("Beverages", category.Name);
    }

    [Fact]
    public async Task CreateCategory_ValidData_CreteCategoryAndReturnsNewObject()
    {
        var category = await _service.AddCategory("Test", "CreateCategory_ValidData_CreteCategoryAndReturnsNewObject");
        Assert.Equal("Test", category.Name);
        Assert.Equal("CreateCategory_ValidData_CreteCategoryAndReturnsNewObject", category.Description);

    }

    [Fact]
    public async Task DeleteCategory_ValidId_RemoveTheCategory()
    {
        _categoryRepository.Add(new Category { Description = "DeleteCategory_ValidId_RemoveTheCategory", Name = "Test" }).Returns(new Category { Id = 9, Description = "DeleteCategory_ValidId_RemoveTheCategory", Name = "Test" });
        var category = _service.AddCategory("Test", "DeleteCategory_ValidId_RemoveTheCategory");
        _categoryRepository.GetById(category.Id).Returns(new Category());
        _categoryRepository.Delete(category.Id).Returns(true);
        var result = await _service.DeleteCategory(category.Id);
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteCategory_InvalidId_ReturnsFalse()
    {
        var result = await _service.DeleteCategory(-1);
        Assert.False(result);
    }

    [Fact]
    public async Task UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
    {
        var result = await _service.UpdateCategory(1, "UpdatedName", "UpdatedDescription");
        Assert.True(result);

        var category = await _service.GetCategoryById(1);

        Assert.Equal("UpdatedName", category.Name);
        Assert.Equal("UpdatedDescription", category.Description);

        // cleanup
        await _service.DeleteCategory(category.Id);
    }

    [Fact]
    public async Task UpdateCategory_InvalidID_ReturnsFalse()
    {
        var result = await _service.UpdateCategory(-1, "UpdatedName", "UpdatedDescription");
        Assert.False(result);
    }
}