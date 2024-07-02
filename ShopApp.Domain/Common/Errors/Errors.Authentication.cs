using ErrorOr;

namespace BubberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCredit",
                                                             description: "invalid credential");

        public static Error DuplicateEmail =>
                            Error.Validation(code: "Auth.DuplicateEmail", 
                            description: "Email already exist");
                                                              
    }
}

