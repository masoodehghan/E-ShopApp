using ShopApp.Domain.Common.Models;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Domain.UserAggregate;


public sealed class User : AggregateRoot<UserId, Guid>
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public long? PhoneNumber { get; private set; }

    public Roles Role { get; private set; } = Roles.Buyer;


    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string hashedPassword,
        string username,
        long? phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        HashedPassword = hashedPassword;
        Username = username;
        PhoneNumber = phoneNumber;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string hashedPassword,
        string username,
        long? phoneNumber)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            hashedPassword,
            username,
            phoneNumber
        );
    }


   #pragma warning disable CS8618
    private User()
    { }
    #pragma warning restore CS8618
}

