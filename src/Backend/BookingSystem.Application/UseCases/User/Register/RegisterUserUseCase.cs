using BookingSystem.Communication.Requests;
using BookingSystem.Communication.Responses;
using BookingSystem.Exceptions.ExceptionsBase;

namespace BookingSystem.Application.UseCases.User.Register;
public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        //mapear request em uma entidade

        //criptografia da senha 

        //salvar no banco de dados

        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
