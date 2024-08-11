using FluentValidation;

namespace Papara_.NET_Bootcamp.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Genre ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Genre name is required.")
                .MaximumLength(100).WithMessage("Genre name cannot exceed 100 characters.");
        }
    }
}
