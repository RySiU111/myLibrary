using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myLibrary.API.Models;

namespace myLibrary.API.Data
{
    public interface ILibraryRepository
    {
        void DeleteBook (Book book);
        Task<bool> SaveAll();
        void AddBook (Book book);
        Task<Book> GetBook(int id);
        Task<IEnumerable<Book>> GetBooks();
        void EditBook(Book book);    
        void DeleteAuthor (Author author);
        void AddAuthor (Author author);
        Task<Author> GetAuthor(int id);
        Task<IEnumerable<Author>> GetAuthors();
        void EditAuthor(Author author);
        Task<Book> SearchBook(string search);
        Task<bool> AuthorExist(int id);
    }
}