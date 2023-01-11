using FluentValidation;
using WeirdFoodCombosBackend.Models;

namespace WeirdFoodCombosBackend.Validation
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email address cannot be empty.")
            .EmailAddress().WithMessage("Provide correct email address.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password length must be at least 6 characters.")
                .MaximumLength(100).WithMessage("Password length cannot exceed 100 characters.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[^a-zA-Z\d\s:]+").WithMessage("Password must contain at least one special character.");

            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password).WithMessage("Password does not match.");
        }
    }
}