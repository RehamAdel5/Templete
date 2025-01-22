﻿using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Handlers.Commands.Auth.RevokeToken
{
    public class Validator : AbstractValidator<Commend>
    {

        public Validator(IStringLocalizer<Commend> _localization)
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage(x => _localization.GetString("TokenRequired"));
        }
    }
}
