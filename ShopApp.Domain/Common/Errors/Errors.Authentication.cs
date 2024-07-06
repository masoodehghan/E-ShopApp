using ErrorOr;

namespace ShopApp.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCredit",
                                                             description: "invalid credential");

        public static Error DuplicateEmail =>
                            Error.Validation(code: "Auth.DuplicateEmail", 
                            description: "Email already exist");

        public static Error Forbidden =>
                            Error.Forbidden("Auth.Forbidden",
                            description: "You are not permitted to do this action");                          
    }
}

