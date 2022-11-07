﻿using GameStore.Application.Models.Games.Requests;
using FluentValidation;

namespace GameStore.Application.Models.Games.Validators
{
    internal class AddGameRequestValidator : AbstractValidator<AddGameRequest>
    {
        public AddGameRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Price).LessThanOrEqualTo(1000);
        }
    }
}
