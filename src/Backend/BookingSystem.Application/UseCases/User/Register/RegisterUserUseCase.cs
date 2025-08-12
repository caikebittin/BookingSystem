using BookingSystem.Application.Services.AutoMapper;
using BookingSystem.Application.Services.Cryptography;
using BookingSystem.Communication.Requests;
using BookingSystem.Communication.Responses;
using BookingSystem.Domain.Repositories.User;
using BookingSystem.Exceptions.ExceptionsBase;

namespace BookingSystem.Application.UseCases.User.Register;
public class RegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        var passwordEncryption = new PasswordEncripter();
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        Validate(request);

        var user = autoMapper.Map<Domain.Entities.User>(request);

        user.Password = passwordEncryption.Ecrypt(request.Password);

        await _writeOnlyRepository.Add(user);

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
