using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myLibrary.API.Data;
using myLibrary.API.Dtos;
using myLibrary.API.Models;

namespace myLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryRepository _repo;
        private readonly IMapper _mapper;

        public BooksController(ILibraryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostBook (BookForDetailedDto book)
        {
            if(book == null || !await _repo.AuthorExist(book.AuthorId))
            {
                return StatusCode(400);
            }
            var bookToSave = _mapper.Map<Book>(book);
            
            if(book.Id == 0)
            {
                _repo.AddBook(bookToSave);
            } 
            else 
            {
                _repo.EditBook(bookToSave);
            }

            await _repo.SaveAll();
            return StatusCode(201, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook (int id)
        {
            var bookToDelete = await _repo.GetBook(id);
            if(bookToDelete != null)
            {
                _repo.DeleteBook(bookToDelete);
                await _repo.SaveAll();
                return StatusCode(200);
            }
            else 
            {
                return StatusCode(404);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _repo.GetBook(id);
            if(book != null)
            {
                var bookToReturn = _mapper.Map<BookForDetailedDto>(book);
                return Ok(bookToReturn);
            } 
            else 
            {
                return new OkObjectResult(null) {StatusCode = 404};
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repo.GetBooks();
            if(books != null)
            {
                var booksToReturn = _mapper.Map<IEnumerable<BookForListDto>>(books);
                return Ok(booksToReturn);
            }
            else 
            {
                return new OkObjectResult(null) {StatusCode = 404};
            }
        }

        [Route("[action]/{search}")]
        [HttpGet]
        public async Task<IActionResult> SearchBook(string search)
        {
            var book = await _repo.SearchBook(search);
            if(book != null)
            {
                var bookToReturn = _mapper.Map<BookForDetailedDto>(book);
                return Ok(bookToReturn);
            }
            else 
            {
                return new OkObjectResult(null) {StatusCode = 404};
            }
        }
    }
}
