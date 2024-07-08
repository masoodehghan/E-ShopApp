namespace ShopApp.Contracts.Categories;


public record CategoryRequest(
    string Name
);


public record CategoryUpdateRequest(
    string Id,
    string Name
);

