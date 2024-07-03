namespace ShopApp.Contracts.Authentication;


public record CreateSuperUserRequest(
    string FirstName,
    string Username,
    string LastName,
    string Email,
    string Password,
    long? PhoneNumber,
    string Secret
);
