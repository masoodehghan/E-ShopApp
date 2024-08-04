using ShopApp.Domain.Common.Models;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.UserAggregate.Events;
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

    public Roles? Role { get; private set; } = null;


    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string hashedPassword,
        string username,
        long? phoneNumber,
        Roles role = Roles.Buyer)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        HashedPassword = hashedPassword;
        Username = username;
        PhoneNumber = phoneNumber;
        Role = role;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string hashedPassword,
        string username,
        long? phoneNumber,
        Roles role = Roles.Buyer)
    {
        User user =  new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            hashedPassword,
            username,
            phoneNumber,
            role
        );

        user.AddDomainEvents(new UserCreated(user));
        return user;
    }


   #pragma warning disable CS8618
    private User()
    { }
    #pragma warning restore CS8618
}

