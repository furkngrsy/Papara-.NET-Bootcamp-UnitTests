using AutoMapper;
using Papara_.NET_Bootcamp.DTOs;
using Papara_.NET_Bootcamp.GenreOperations.Commands.CreateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.UpdateGenre;

namespace Papara_.NET_Bootcamp.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<CreateGenreCommand, Genre>();
            CreateMap<UpdateGenreCommand, Genre>();
        }
    }
}
