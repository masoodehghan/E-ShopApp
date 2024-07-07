namespace ShopApp.Contracts.Categories;


public record CategoryResponse(
    string Id,
    List<string> ProductIds,
    string Name
);

