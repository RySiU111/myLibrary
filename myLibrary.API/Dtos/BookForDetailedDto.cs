using System;

namespace myLibrary.API.Dtos
{
    public class BookForDetailedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int AuthorId { get; set; }
        public AuthorForBookDetailedDto Author { get; set; }
    }
}