using BookingSystem.Communication.Requests;
using BookingSystem.Communication.Responses;

namespace BookingSystem.Application.UseCases.User.Register;
public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
