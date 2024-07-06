namespace ShopApp.Contracts.Products;


public record ProductResponse(
    string Id,
    string Name,
    int Quantity,
    string CategoryId,
    float Price,
    string Description
);
