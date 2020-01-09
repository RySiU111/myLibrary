using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myLibrary.API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}