using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Papara.NET.Bootcamp.Models.Entities;
using Papara.NET.Bootcamp.Services.Repositories;

namespace Papara.NET.Bootcamp.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            AuthorRepository = new AuthorRepository(_context);
            // Diğer repository'leri initialize edin
        }

        public IAuthorRepository AuthorRepository { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
