using MediatR;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Common.Interfaces;
using AppUser = RO.DevTest.Domain.Entities.User; // <-- Aqui em cima é o lugar certo

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
            throw new UnauthorizedAccessException("Credenciais inválidas");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
            throw new UnauthorizedAccessException("Credenciais inválidas");

        var token = _jwtService.GenerateToken(user);

        return new LoginResponse
        {
             AccessToken = token,
            Email = user.Email!,
            UserId = user.Id,
             ExpirationDate = DateTime.UtcNow.AddHours(1)      

        };
    }
}
