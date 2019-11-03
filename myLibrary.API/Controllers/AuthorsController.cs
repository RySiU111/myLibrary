using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myLibrary.API.Data;
using myLibrary.API.Dtos;
using myLibrary.API.Models;

namespace myLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _repo;
        private readonly IMapper _mapper;

        public AuthorsController(ILibraryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthor (AuthorForDetailedDto author)
        {
            if(author == null)
            {
                return StatusCode(400);
            }
            var authorToSave = _mapper.Map<Author>(author);
            
            if(author.Id == 0)
            {
                _repo.AddAuthor(authorToSave);
            } 
            else 
            {
                _repo.EditAuthor(authorToSave);
            }

            await _repo.SaveAll();
            return StatusCode(201, author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor (int id)
        {
            var authorToDelete = await _repo.GetAuthor(id);
            if(authorToDelete != null)
            {
                _repo.DeleteAuthor(authorToDelete);
                await _repo.SaveAll();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _repo.GetAuthor(id);
            if(author != null)
            {
                var authorToReturn = _mapper.Map<AuthorForDetailedDto>(author);
                return Ok(authorToReturn);
            }
            else
            {
                return new OkObjectResult(null) {StatusCode = 404};
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _repo.GetAuthors();
            if(authors != null)
            {
                var authorsToReturn = _mapper.Map<IEnumerable<AuthorForListDto>>(authors);
                return Ok(authorsToReturn);
            }
            else
            {
                return new OkObjectResult(null) {StatusCode = 404};
            }
        }
    }
}