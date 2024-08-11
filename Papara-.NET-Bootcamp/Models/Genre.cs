using Papara.NET.Bootcamp.Models.Entities;

namespace Papara_.NET_Bootcamp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } 
    }

}
