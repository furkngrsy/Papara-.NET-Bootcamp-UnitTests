using FluentValidation;

namespace Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Genre ID must be greater than 0.");
        }
    }
}
