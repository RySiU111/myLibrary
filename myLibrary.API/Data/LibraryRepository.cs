using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myLibrary.API.Models;

namespace myLibrary.API.Data
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly DataContext _context;

        public LibraryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public void EditAuthor(Author author)
        {
            _context.Authors.Update(author);
        }

        public void EditBook(Book book)
        {
            _context.Books.Update(book);
        }

        public async Task<Author> GetAuthor(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}