namespace Application.Handlers.Commands.Auth.RefreshToken.Dto;
public record RefreshTokenResponseDTO(string? Username, string? Email, List<string>? Roles, string? Token, DateTime ExpiresOn, string? RefreshToken, DateTime? RefreshTokenExpiration);



