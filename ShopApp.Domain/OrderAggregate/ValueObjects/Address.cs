using ShopApp.Domain.Common.Models;

namespace ShopApp.Domain.OrderAggregate.ValueObjects;


public sealed class Address : ValueObject
{
    public string City { get; private set; }
    public string Street { get; private set; }

    public int Code { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return Code;
    }


    private Address(string city, string street, int code)
    {
        City = city;
        Street = street;
        Code = code;
    }

    public static Address Create(string city, string street, int code)
    {
        return new(city, street, code);
    }
}
