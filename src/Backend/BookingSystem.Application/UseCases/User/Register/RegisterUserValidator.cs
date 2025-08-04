using BookingSystem.Communication.Requests;
using FluentValidation;

namespace BookingSystem.Application.UseCases.User.Register;
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
   public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
        RuleFor(user => user.Email).NotEmpty().WithMessage("O email não pode ser vazio.");
        RuleFor(user => user.Email).EmailAddress();
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8);
    } 
}
