using System;

namespace myLibrary.API.Dtos
{
    public class BookForDetailedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; } 
        public string Description { get; set; }
    }
}