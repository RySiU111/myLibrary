using AutoMapper;
using myLibrary.API.Dtos;
using myLibrary.API.Models;

namespace myLibrary.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookForListDto>();
            CreateMap<Book, BookForDetailedDto>();
            CreateMap<BookForDetailedDto, Book>();      
            CreateMap<Book, BookForAuthorDetailedDto>();
            
            CreateMap<Author, AuthorForListDto>();
            CreateMap<Author, AuthorForDetailedDto>();
            CreateMap<AuthorForDetailedDto, Author>();
            CreateMap<Author, AuthorForBookListDto>();
            CreateMap<Author, AuthorForBookDetailedDto>();
            CreateMap<AuthorForBookDetailedDto, Author>();
        }
    }
}