using BookingSystem.Communication.Requests;
using BookingSystem.Exceptions;
using FluentValidation;

namespace BookingSystem.Application.UseCases.User.Register;
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
   public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8).WithMessage(ResourceMessagesException.PASSWORD_SHORT);
    } 
}
