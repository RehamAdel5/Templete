using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands.Auth.SendCode
{
    public class Commend : IRequest<AuthModel>
    {
        public string Email { get; set; } = null!;
    }
}
