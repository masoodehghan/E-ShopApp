using ShopApp.Domain.Common;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Domain.UserAggregate;


public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public long? PhoneNumber { get; private set; }

    public Roles Role { get; private set; } = Roles.Buyer;



}

