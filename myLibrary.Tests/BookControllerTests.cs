using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using myLibrary.API.Controllers;
using myLibrary.API.Data;
using myLibrary.API.Dtos;
using myLibrary.API.Helpers;
using myLibrary.API.Models;
using Xunit;

namespace myLibrary.Tests
{
    public class BookControllerTests
    {
        [Fact]
        public async Task GetBook_ValidId_ReturnedOkObjectResultNotNullStatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetBook(It.IsInRange<int>(1, 3, Range.Inclusive))).ReturnsAsync( new  Book(){
                Id = 1, Title = "KK", Description = "Testowanie"}); 
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.GetBook(1);
            var okObjectResult = result as OkObjectResult;
            var model = okObjectResult.Value as BookForDetailedDto;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task GetBook_InvalidId_ReturnedOkObjectResultIsNotNullStatusCode404()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetBook(It.Is<int>(id => id > 3))).ReturnsAsync((Book)null); 
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.GetBook(4);
            var okObjectResult = result as OkObjectResult;
            var model = okObjectResult.Value as BookForDetailedDto;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(404, okObjectResult.StatusCode);
            Assert.Null(model);
        }

        [Fact]
        public async Task GetBooks_ReturnedOkObjectResultNotNullStatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetBooks()).ReturnsAsync(new List<Book>(){
                new Book(), new Book()
            });
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.GetBooks();
            var okObjectResult = result as OkObjectResult;
            var list = okObjectResult.Value as List<BookForListDto>;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public async Task GetBooks_ListIsNull_StatusCode404()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetBooks()).ReturnsAsync((List<Book>)null);
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.GetBooks();
            var okObjectResult = result as OkObjectResult;
            var list = okObjectResult.Value as List<BookForListDto>;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(404, okObjectResult.StatusCode);
            Assert.Null(list);
        }

        [Fact]
        public async Task PostBook_PassBookForDetailedDtoObject_StatusCode201()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            BookForDetailedDto book = new BookForDetailedDto() {Id = 1, Title = "Test", Description = "Testing"};
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.PostBook(book);
            var objectResult = result as ObjectResult;

            //Assert
            Assert.NotNull(objectResult);
            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async Task PostBook_PassNull_StatusCode400()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            BookForDetailedDto book = null;
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.PostBook(book);
            var statusCode = result as StatusCodeResult;

            //Assert
            Assert.NotNull(statusCode);
            Assert.Equal(400, statusCode.StatusCode);
        }

        [Fact]
        public async Task DeleteBook_ValidId_StatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetBook(It.IsInRange<int>(1, 3, Range.Inclusive))).ReturnsAsync( new  Book(){
                Id = 1, Title = "KK", Description = "Testowanie"}); 
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.DeleteBook(1);
            var statusCode = result as StatusCodeResult;

            //Assert
            Assert.NotNull(statusCode);
            Assert.Equal(200, statusCode.StatusCode);
        }

        [Fact]
        public async Task DeleteBook_InvalidId_StatusCode404()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetBook(It.Is<int>(id => id > 3))).ReturnsAsync((Book)null); 
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.DeleteBook(4);
            var statusCode = result as StatusCodeResult;

            //Assert
            Assert.NotNull(statusCode);
            Assert.Equal(404, statusCode.StatusCode);
        }

        [Fact]
        public async Task SearchBook_ParamEqualsTitle_ReturnedOkObjectResultNotNullStatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.SearchBook("Test")).ReturnsAsync( new  Book(){
                Id = 1, Title = "Test", Description = "Testowanie"}); 
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.SearchBook("Test");
            var okObjectResult = result as OkObjectResult;
            var model = okObjectResult.Value as BookForDetailedDto;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(model);
            Assert.Equal("Test", model.Title);
        }

        [Fact]
        public async Task SearchBook_ParamNotEqualsTitle_ReturnedOkObjectResultNotNullStatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.SearchBook("Test")).ReturnsAsync( (Book)null);
            var controller = new BooksController(repository.Object, mapper);

            //Act
            var result = await controller.SearchBook("Test");
            var okObjectResult = result as OkObjectResult;
            var model = okObjectResult.Value as BookForDetailedDto;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(404, okObjectResult.StatusCode);
            Assert.Null(model);
        }        
    }
}
