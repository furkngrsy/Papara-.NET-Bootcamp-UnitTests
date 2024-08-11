using AutoMapper;
using Papara_.NET_Bootcamp.DTOs;
using Papara_.NET_Bootcamp.GenreOperations.Commands.CreateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.DeleteGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.UpdateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenreDetail;
using Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenres;

namespace Papara_.NET_Bootcamp.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreDTO> CreateGenreAsync(CreateGenreCommand command)
        {
            var genre = _mapper.Map<Genre>(command);
            await _genreRepository.AddAsync(genre);
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task UpdateGenreAsync(UpdateGenreCommand command)
        {
            var genre = await _genreRepository.GetByIdAsync(command.Id);
            if (genre == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }

            _mapper.Map(command, genre);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreAsync(DeleteGenreCommand command)
        {
            var genre = await _genreRepository.GetByIdAsync(command.Id);
            if (genre == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }

            await _genreRepository.DeleteAsync(genre);
        }

        public async Task<GenreDTO> GetGenreDetailAsync(GetGenreDetailQuery query)
        {
            var genre = await _genreRepository.GetByIdAsync(query.Id);
            if (genre == null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task<IEnumerable<GenreDTO>> GetGenresAsync(GetGenresQuery query)
        {
            var genres = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }
    }
}
