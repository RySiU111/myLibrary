using System;
using Microsoft.EntityFrameworkCore;
using myLibrary.API.Models;

namespace myLibrary.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Book> Books { get; set; }     
        public DbSet<Author> Authors { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var defaultPhotoUrl = "https://material.angular.io/assets/img/examples/shiba2.jpg";
            var description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.";


            modelBuilder.Entity<Author>().HasData(
                new Author {Id = 1, Name = "Jan", Surname = "Kowalski", Description = description, PhotoUrl = defaultPhotoUrl},
                new Author {Id = 2, Name = "Adam", Surname = "Skarbek", Description = description, PhotoUrl = defaultPhotoUrl},
                new Author {Id = 3, Name = "Ala", Surname = "Kucz", Description = description, PhotoUrl = defaultPhotoUrl}
            );

            modelBuilder.Entity<Book>().HasData(
                new Book {Id = 1,AuthorId = 1, Title = "Lorem Ipsum", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2020,2,1)},
                new Book {Id = 2,AuthorId = 1, Title = "Nulla congue", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2020,3,21)},
                new Book {Id = 3,AuthorId = 1, Title = "Etiam maximus", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2019,4,10)},
                new Book {Id = 4,AuthorId = 1, Title = "Integer dapibus", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2016,2,15)},
                new Book {Id = 5,AuthorId = 2, Title = "Aliquam nec", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2020,12,2)},
                new Book {Id = 6,AuthorId = 2, Title = "Praesent luctus", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2015,11,1)},
                new Book {Id = 7,AuthorId = 2, Title = "Nam porttitor", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2018,3,11)},
                new Book {Id = 8,AuthorId = 3, Title = "Sed placerat", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2019,5,10)},
                new Book {Id = 9,AuthorId = 3, Title = "In maximus", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2020,8,9)},
                new Book {Id = 10,AuthorId = 3, Title = "Nullam ac", Description = description, PhotoUrl = defaultPhotoUrl, ReleaseDate = new DateTime(2020,10,11)}
            );
        }
    }
}