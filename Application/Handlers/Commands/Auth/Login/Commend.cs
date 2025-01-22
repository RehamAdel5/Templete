﻿using Application.Handlers.Commands.Auth.Login.Dto;
using Application.Mappings;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Handlers.Commands.Auth.Login
{
    public class Commend : IRequest<LoginResponseDTO>, IMapFrom<TokenRequestModel>
    {
        public LoginDto? Model { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginDto, TokenRequestModel>().ReverseMap()
                 .IgnoreAllNonExisting();
            profile.CreateMap<LoginResponseDTO, AuthModel>().ReverseMap()
                .IgnoreAllNonExisting();
        }
    }
}
