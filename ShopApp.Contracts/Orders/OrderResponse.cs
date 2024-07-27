namespace ShopApp.Contracts.Orders;


public class OrderResponse
{
    public string? OrderId { get; set; }
    public string? Number { get; set; }
    public AddressResponse? Address { get; set; }
    public List<OrderItemResponse> OrderItems { get; set; } = new(); 
}



public class AddressResponse
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public int Code { get; set; } 
}


public class OrderItemResponse
{
    public string? ProductId { get; set; }
    public int Quantity { get; set; }
}

