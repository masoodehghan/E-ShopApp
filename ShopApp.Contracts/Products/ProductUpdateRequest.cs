namespace ShopApp.Contracts.Products;

public record ProductUpdateRequest(
    string? Name,
    string? Description,
    float? Price,
    int? Quantity,
    string? CategoryId,
    string? Id
);
