using System.Text.Json.Serialization;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public record LoginResponse 
{
    [JsonPropertyName("token")] 
    public string AccessToken { get; set; } 
    
    [JsonIgnore]
    public string Email { get; set; }
    
    [JsonIgnore]
    public string UserId { get; set; }

    public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpirationDate { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<string>? Roles { get; set; } = null;
}