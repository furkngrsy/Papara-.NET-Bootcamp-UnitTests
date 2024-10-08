﻿namespace Papara.NET.Bootcamp.Models.DTOs
{
    public class AuthorReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
}
