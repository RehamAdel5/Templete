namespace Application.Handlers.Commands.Auth.Register.Dto;
public record RegisterResponseDTO(string? Message, string? Username, string? Email, List<string>? Roles, string? Token, int Code, DateTime? ExpiresOn, string? RefreshToken, DateTime? RefreshTokenExpiration);

