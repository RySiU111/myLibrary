using System.Collections.Generic;

namespace myLibrary.API.Dtos
{
    public class AuthorForDetailedDto
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public List<BookForAuthorDetailedDto> Books { get; set; }
    }
}