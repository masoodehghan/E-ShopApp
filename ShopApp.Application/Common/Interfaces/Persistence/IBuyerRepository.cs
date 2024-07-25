using ShopApp.Domain.BuyerAggregate;

namespace ShopApp.Application.Common.Interfaces.Persistence;


public interface IBuyerRepository
{
    Task Add(Buyer buyer);
}
