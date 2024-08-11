namespace Papara.NET.Bootcamp.Models.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } // Author adını da ekleyebiliriz
    }
}
