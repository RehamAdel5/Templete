using MediatR;

namespace Application.Handlers.Commands.Auth.RevokeToken
{
    public class Commend : IRequest<bool>
    {
        public string Token { get; set; } = null!;

    }
}
