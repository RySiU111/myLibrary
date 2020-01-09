using System;

namespace myLibrary.API.Dtos
{
    public class BookForAuthorDetailedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public string PhotoUrl { get; set; }
    }
}