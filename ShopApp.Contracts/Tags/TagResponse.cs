using ShopApp.Contracts.Products;

namespace ShopApp.Contracts.Tags;


public class TagResponse
{
    public string? TagId { get; set; }
    public string? Name { get; set; }

    public List<ProductResponse> Products { get; set; } = new(); 
}
