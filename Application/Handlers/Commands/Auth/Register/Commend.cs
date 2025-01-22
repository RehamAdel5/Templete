using Application.Handlers.Commands.Auth.Register.Dto;
using Application.Mappings;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands.Auth.Register
{
    public class Commend : IRequest<RegisterResponseDTO>, IMapFrom<RegisterModel>
    {
        public RegisterDto? Model { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, RegisterModel>().ReverseMap()
                 .IgnoreAllNonExisting();
            profile.CreateMap<AuthModel, RegisterResponseDTO>().ReverseMap()
                 .IgnoreAllNonExisting();
        }
    }
}
