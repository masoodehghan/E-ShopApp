using ShopApp.Domain.BuyerAggregate;
using ShopApp.Domain.UserAggregate;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IBuyerRepository
{
    Task Add(Buyer buyer);
    Task<Buyer> GetByUserId(UserId userId);
}
