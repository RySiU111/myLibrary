using System;

namespace myLibrary.API.Dtos
{
    public class BookForListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string PhotoUrl { get; set; }
        public int AuthorId { get; set; }
        public AuthorForBookListDto Author { get; set; }
    }
}