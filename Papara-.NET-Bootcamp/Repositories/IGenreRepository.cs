namespace Papara_.NET_Bootcamp.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> GetByIdAsync(int id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(Genre genre);
    }

}
