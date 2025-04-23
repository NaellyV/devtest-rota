namespace RO.DevTest.Application.Features.User.Commands.CreateUserCommand;

public record CreateUserResult
{
    public string Id { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Message { get; init; } = "Usuário criado com sucesso"; 
    public CreateUserResult() { }

    public CreateUserResult(Domain.Entities.User user) 
    {
        Id = user.Id;
        UserName = user.UserName ?? string.Empty;
        Email = user.Email ?? string.Empty;
        Name = user.Name ?? string.Empty;
    }
}