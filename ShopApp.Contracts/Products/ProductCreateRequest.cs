namespace ShopApp.Contracts.Products;


public record ProductCreateRequest(
    string Name,
    int Quantity,
    Guid CategoryId,
    float Price,
    string? Description
);