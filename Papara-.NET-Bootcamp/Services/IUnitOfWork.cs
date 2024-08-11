using System;
using System.Threading.Tasks;

namespace Papara.NET.Bootcamp.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository AuthorRepository { get; }
        // Diğer repository'ler
        Task<int> CompleteAsync();
    }
}
