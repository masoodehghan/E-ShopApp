using ErrorOr;

namespace ShopApp.Domain.Common.Errors;


public static partial class Errors
{
    public static class Category
    {
        public static Error NotFound => Error.Validation(code: "category id not found");
    }
}
