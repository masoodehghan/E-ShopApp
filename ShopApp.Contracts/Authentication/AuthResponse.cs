namespace ShopApp.Contracts.Authentication;


public record AuthResponse(
    string Id,
    string FirstName,
    string Username,
    string LastName,
    string Email,
    long? PhoneNumber
);
