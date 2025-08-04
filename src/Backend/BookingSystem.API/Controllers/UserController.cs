using BookingSystem.Application.UseCases.User.Register;
using BookingSystem.Communication.Requests;
using BookingSystem.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterUserJson request)
    {
        var useCase = new RegisterUserUseCase();

        var result = useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
