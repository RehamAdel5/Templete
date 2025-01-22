namespace Application.Handlers.Commands.Auth.Login.Dto;
public record LoginResponseDTO(string? Username, string? Email, List<string>? Roles, string? Token, DateTime ExpiresOn, string? RefreshToken, DateTime? RefreshTokenExpiration);



