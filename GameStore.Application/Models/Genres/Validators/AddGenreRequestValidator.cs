using FluentValidation;
using GameStore.Application.Models.Genres.Requests;

namespace GameStore.Application.Models.Genres.Validators
{
    internal class AddGenreRequestValidator : AbstractValidator<AddGenreRequest>
    {
        public AddGenreRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
        }
    }
}
