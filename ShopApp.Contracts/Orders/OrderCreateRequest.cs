namespace ShopApp.Contracts.Orders;


public record OrderCreateRequest(
    AddressRequest Address,
    List<OrderItemRequest> OrderItems 
);


public record AddressRequest(
    string City,
    string Street,
    int Code
);

public record OrderItemRequest(
    string ProductId,
    int Quantity
);

