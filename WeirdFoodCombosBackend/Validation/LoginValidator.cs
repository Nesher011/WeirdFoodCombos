using FluentValidation;
using WeirdFoodCombosBackend.Models;

namespace WeirdFoodCombosBackend.Validation
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Email address cannot be empty.")
                .EmailAddress().WithMessage("Email address is not correct");
            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}