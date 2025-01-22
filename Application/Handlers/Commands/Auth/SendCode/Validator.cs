﻿using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Application.Handlers.Commands.Auth.SendCode
{
    public class Validator : AbstractValidator<Commend>
    {

        public Validator(IStringLocalizer<Commend> _localization)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(x => _localization.GetString("EmailRequired"))
                                  .EmailAddress().WithMessage(x => _localization.GetString("EmailvalidRequired"));
        }
    }
}
