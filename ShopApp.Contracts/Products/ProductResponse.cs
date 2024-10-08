using ShopApp.Contracts.Categories;
using ShopApp.Contracts.Tags;

namespace ShopApp.Contracts.Products;


public class ProductResponse {
    public string? ProductId { get; set; }
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public CategoryResponse? Category { get; set; }
    public float? Price { get; set; }
    public string? Description { get; set; }
    public bool? IsAvailable { get; set; }
    public List<TagResponse> Tags { get; set; } = new();
};
