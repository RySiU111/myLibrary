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
            var bookToSave = _mapper.Map<Book>(book);
            
            if(book.Id == 0){
                _repo.AddBook(bookToSave);
            } else {
                _repo.EditBook(bookToSave);
            }

            await _repo.SaveAll();
            return StatusCode(201, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook (int id)
        {
            var bookToDelete = await _repo.GetBook(id);
            _repo.DeleteBook(bookToDelete);
            await _repo.SaveAll();
            return Ok(bookToDelete);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _repo.GetBook(id);
            var bookToReturn = _mapper.Map<BookForDetailedDto>(book);
            return Ok(bookToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repo.GetBooks();
            var booksToReturn = _mapper.Map<IEnumerable<BookForListDto>>(books);
            return Ok(booksToReturn);
        }
    }
}
