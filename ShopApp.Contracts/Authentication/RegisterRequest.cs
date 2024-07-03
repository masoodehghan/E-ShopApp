namespace ShopApp.Contracts.Authentication;


public record RegisterRequest(
    string FirstName,
    string Username,
    string LastName,
    string Email,
    string Password,
    long? PhoneNumber
);
