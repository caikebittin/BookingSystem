using BookingSystem.Application.Services.AutoMapper;
using BookingSystem.Application.Services.Cryptography;
using BookingSystem.Application.UseCases.User.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BookingSystem.Application;
public static class DepedencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddPasswordEncrpter(services);
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    private static void AddPasswordEncrpter(IServiceCollection services)
    {
        services.AddScoped(option => new PasswordEncripter());
    }
}