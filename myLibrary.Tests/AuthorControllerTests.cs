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
    public class AuthorControllerTests
    {
        [Fact]
        public async Task GetAuthor_ValidId_ReturnedOkObjectResultNotNullStatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetAuthor(It.IsInRange<int>(1, 3, Range.Inclusive))).ReturnsAsync( new  Author(){
                Id = 1, Name = "Jan", Surname = "Kowalski"}); 
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.GetAuthor(1);
            var okObjectResult = result as OkObjectResult;
            var model = okObjectResult.Value as AuthorForDetailedDto;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task GetAuthor_InvalidId_ReturnedOkObjectResultIsNotNullStatusCode404()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetAuthor(It.Is<int>(id => id > 3))).ReturnsAsync((Author)null); 
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.GetAuthor(4);
            var okObjectResult = result as OkObjectResult;
            var model = okObjectResult.Value as AuthorForDetailedDto;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(404, okObjectResult.StatusCode);
            Assert.Null(model);
        }

        [Fact]
        public async Task GetAuthors_ReturnedOkObjectResultNotNullStatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetAuthors()).ReturnsAsync(new List<Author>(){
                new Author(), new Author()
            });
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.GetAuthors();
            var okObjectResult = result as OkObjectResult;
            var list = okObjectResult.Value as List<AuthorForListDto>;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public async Task GetAuthors_ListIsNull_StatusCode404()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetAuthors()).ReturnsAsync((List<Author>)null);
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.GetAuthors();
            var okObjectResult = result as OkObjectResult;
            var list = okObjectResult.Value as List<AuthorForListDto>;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(404, okObjectResult.StatusCode);
            Assert.Null(list);
        }

        [Fact]
        public async Task PostAuthor_PassBookForDetailedDtoObject_StatusCode201()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            AuthorForDetailedDto author = new AuthorForDetailedDto() {Id = 1, Name = "Jan", Surname = "Kowalski"};
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.PostAuthor(author);
            var objectResult = result as ObjectResult;

            //Assert
            Assert.NotNull(objectResult);
            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async Task PostAuthor_PassNull_StatusCode400()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            AuthorForDetailedDto author = null;
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.PostAuthor(author);
            var statusCode = result as StatusCodeResult;

            //Assert
            Assert.NotNull(statusCode);
            Assert.Equal(400, statusCode.StatusCode);
        }

        [Fact]
        public async Task DeleteAuthor_ValidId_StatusCode200()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetAuthor(It.IsInRange<int>(1, 3, Range.Inclusive))).ReturnsAsync( new  Author(){
                Id = 1, Name = "Jan", Surname = "Kowalski"}); 
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.DeleteAuthor(1);
            var statusCode = result as StatusCodeResult;

            //Assert
            Assert.NotNull(statusCode);
            Assert.Equal(200, statusCode.StatusCode);
        }

        [Fact]
        public async Task DeleteAuthor_InvalidId_StatusCode404()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile( new AutoMapperProfiles());
            });
            var repository = new Mock<ILibraryRepository>();
            var mapper = config.CreateMapper();
            repository.Setup(r => r.GetAuthor(It.Is<int>(id => id > 3))).ReturnsAsync((Author)null); 
            var controller = new AuthorsController(repository.Object, mapper);

            //Act
            var result = await controller.DeleteAuthor(4);
            var statusCode = result as StatusCodeResult;

            //Assert
            Assert.NotNull(statusCode);
            Assert.Equal(404, statusCode.StatusCode);
        } 
    }
}