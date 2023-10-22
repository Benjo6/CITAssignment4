using CITAssignment4.DataLayer.Domain;
using CITAssignment4.DataLayer.Generics;
using CITAssignment4.DataLayer.Service;
using NSubstitute;

namespace CITAssignment4.DataLayer.Tests.Services;

public class ProductServiceTests
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _productRepository = Substitute.For<IGenericRepository<Product>>();
        _service = new ProductService(_productRepository);

        // Set up the substitute for GetProductById
        _productRepository.GetById(1).Returns(new Product
        {
            Id = 1,
            Name = "Chai",
            Category = new Category { Name = "Beverages" }
        });

        // Set up the substitute for GetProductsByCategoryId
        _productRepository.GetAll().Returns(new List<Product>
        {
            new()
            {
                Id = 1,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Beverages" },
            },
            new()
            {
                Id = 2,
                Name = "NuNuCa Nuß-Nougat-Creme",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },
            new()
            {
                Id = 3,
                Name = "NuNuCa Nuß-Nougat-Creme",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },
            new()
            {
                Id = 4,
                Name = "NuNuCa Nuß-Nougat-Creme",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },
            new()
            {
                Id = 5,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },
            new()
            {
                Id = 6,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },
            new()
            {
                Id = 7,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },            new()
            {
                Id = 8,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },            new()
            {
                Id = 9,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },            new()
            {
                Id = 10,
                Name = "Chai",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },            new()
            {
                Id = 11,
                Name = "Flotemysost",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },            new()
            {
                Id = 12,
                Name = "Lakkalikööri",
                CategoryId = 1,
                Category = new Category { Name = "Confections" },
            },
        });
    }
    
    [Fact]
    public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
    {
        var product = new Product();
        Assert.Equal(0, product.Id);
        Assert.Null(product.Name);
        Assert.Equal(0.0, product.UnitPrice);
        Assert.Null(product.QuantityPerUnit);
        Assert.Equal(0, product.UnitsInStock);
    }

    [Fact]
    public async Task GetProduct_ValidId_ReturnsProductWithCategory()
    {
        var product = await _service.GetProductById(1);
        Assert.Equal("Chai", product.Name);
        Assert.Equal("Beverages", product.Category.Name);
    }

    [Fact]
    public async Task GetProductsByCategory_ValidId_ReturnsProductWithCategory()
    {
        var products = await _service.GetProductsByCategoryId(1);
        Assert.Equal(12, products.Count);
        Assert.Equal("Chai", products.First().Name);
        Assert.Equal("Beverages", products.First().Category.Name);
        Assert.Equal("Lakkalikööri", products.Last().Name);
    }

    [Fact]
    public async Task GetProduct_NameSubString_ReturnsProductsThatMatchesTheSubString()
    {
        var products = await _service.GetProductsBySubstring("em");
        Assert.Equal(4, products.Count);
        Assert.Equal("NuNuCa Nuß-Nougat-Creme", products.First().Name);
        Assert.Equal("Confections", products.First().Category.Name);
        Assert.Equal("Flotemysost", products.Last().Name);
    }
}