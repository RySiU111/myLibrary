using System;
using System.ComponentModel.DataAnnotations;

namespace myLibrary.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public DateTime? ReleaseDate { get; set; } 
        public string Description { get; set; }  
        //public int AuthorId { get; set; } 
    }
}