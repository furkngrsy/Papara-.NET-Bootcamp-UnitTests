using FluentValidation;

namespace Papara_.NET_Bootcamp.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Genre ID must be greater than 0.");
        }
    }
}
