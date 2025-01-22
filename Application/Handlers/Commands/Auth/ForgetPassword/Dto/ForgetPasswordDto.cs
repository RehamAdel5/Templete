namespace Application.Handlers.Commands.Auth.ForgetPassword.Dto;
public record ForgetPasswordDto(string Email = null!, int Code = 0, string NewPassword = null!);


