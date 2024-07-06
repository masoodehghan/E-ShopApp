namespace ShopApp.Contracts.Products;


public record ProductCreateRequest(
    string Name,
    int Quantity,
    string CategoryId,
    float Price,
    string? Description
);