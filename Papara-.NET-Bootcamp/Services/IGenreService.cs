using Papara_.NET_Bootcamp.DTOs;
using Papara_.NET_Bootcamp.GenreOperations.Commands.CreateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.DeleteGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.UpdateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenreDetail;
using Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenres;

namespace Papara_.NET_Bootcamp.Services
{
    public interface IGenreService
    {
        Task<GenreDTO> CreateGenreAsync(CreateGenreCommand command);
        Task UpdateGenreAsync(UpdateGenreCommand command);
        Task DeleteGenreAsync(DeleteGenreCommand command);
        Task<GenreDTO> GetGenreDetailAsync(GetGenreDetailQuery query);
        Task<IEnumerable<GenreDTO>> GetGenresAsync(GetGenresQuery query);
    }

}
