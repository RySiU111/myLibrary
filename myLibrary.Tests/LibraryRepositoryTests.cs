using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using myLibrary.API.Data;
using myLibrary.API.Models;
using Xunit;

namespace myLibrary.Tests
{
    public class LibraryRepositoryTests
    {
        [Fact]
        public void AddAuthor_PassAuthorObject_AuthorAddedToDatabse()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("Add_author_to_database").Options;
            var author = new Author {Name = "Test", Surname = "Test"};

            //Act
            using (var context = new DataContext(options))
            {
                var repo = new LibraryRepository(context);
                repo.AddAuthor(author);
                context.SaveChanges();
            }

            //Assert
            using (var context = new DataContext(options))
            {
                Assert.Equal(1, context.Authors.Count());
                Assert.Equal("Test", context.Authors.Single().Name);
            }       
        }

        [Fact]
        public void AddBook_PassBookObject_BookAddedToDatabse()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("Add_book_to_database").Options;
            var book = new Book {Title = "Test", Description = "Test"};

            //Act
            using (var context = new DataContext(options))
            {
                var repo = new LibraryRepository(context);
                repo.AddBook(book);
                context.SaveChanges();
            }

            //Assert
            using (var context = new DataContext(options))
            {
                Assert.Equal(1, context.Books.Count());
                Assert.Equal("Test", context.Books.Single().Title);
            }
        }

        
    }
}