using ErrorOr;

namespace ShopApp.Domain.Common.Errors;


public static partial class Errors
{
    public static class Product
    {
        public static Error NotFound => Error.NotFound(code: "product not found");
    }
}
