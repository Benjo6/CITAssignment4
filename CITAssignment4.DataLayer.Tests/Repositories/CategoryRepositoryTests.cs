/*
using CITAssignment4.DataLayer.Application;
using CITAssignment4.DataLayer.Domain;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Testcontainers.PostgreSql;

namespace CITAssignment4.DataLayer.Tests.Repositories;

public class CategoryRepositoryTests : IAsyncLifetime
{
    private readonly ILogger<CategoryRepository> _logger;

    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .Build();
    public CategoryRepositoryTests()
    {
        _logger = Substitute.For<ILogger<CategoryRepository>>();
    }

    [Fact]
    public async Task CategoryRepository_GetById_ReturnsCategory()
    {
        // Arrange
        var repository = new CategoryRepository(_context, _logger);
        int categoryId = 1;
        var category = new Category { Id = categoryId, Name = "CategoryName" };

        // Act
        var result = await repository.GetById(categoryId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoryId, result.Id);
    }

    [Fact]
    public async Task CategoryRepository_GetAll_ReturnsCategories()
    {
        // Arrange
        var repository = new CategoryRepository(_context, _logger);
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category1" },
            new Category { Id = 2, Name = "Category2" },
        };

        // Act
        var result = await repository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categories.Count, result.Count);
    }

    [Fact]
    public async Task CategoryRepository_AddCategory_ReturnsAddedCategory()
    {
        // Arrange
        var repository = new CategoryRepository(_context, _logger);
        var category = new Category { Name = "NewCategory" };

        var categoryList = new List<Category>(); // Create a list to simulate the DbSet

        // Act
        var result = await repository.Add(category);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(category.Name, result.Name);
        Assert.Contains(result, categoryList);
    }
    
    [Fact]
    public async Task CategoryRepository_UpdateCategory_ReturnsTrue()
    {
        // Arrange
        var repository = new CategoryRepository(_context, _logger);
        var category = new Category { Id = 1, Name = "UpdatedCategory" };

        // Act
        var result = await repository.Update(category);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CategoryRepository_DeleteCategory_ReturnsTrue()
    {
        // Arrange
        var repository = new CategoryRepository(_context, _logger);
        int categoryId = 1;
        
        // Act
        var result = await repository.Delete(categoryId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CategoryRepository_DeleteCategory_ReturnsFalseWhenCategoryNotFound()
    {
        // Arrange
        var repository = new CategoryRepository(_context, _logger);
        int categoryId = 1;

        // Act
        var result = await repository.Delete(categoryId);

        // Assert
        Assert.False(result);
    }

    public Task InitializeAsync()
    {
        return _postgres.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _postgres.DisposeAsync().AsTask();
    }
}
*/
