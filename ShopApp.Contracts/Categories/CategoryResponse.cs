using ShopApp.Contracts.Products;

namespace ShopApp.Contracts.Categories;


public class CategoryResponse {
    public string? CategoryId { get; set; }
    public List<ProductResponse?> Products { get; set; } = new();
    public List<string> ProductIds { get; set; } = new();

    public string? Name { get; set; }
};

