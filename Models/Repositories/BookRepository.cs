using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        IList<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
                {
                   new Book
                   {
                       Id=1 , Title="C# Programming" , 
                       Description="No Description",
                       ImageUrl = "cr.jpg",
                       Author = new Author{Id = 2}
                   },
                   new Book
                   {
                       Id=2 , Title="Java Programming" , 
                       Description="Nothing",
                       ImageUrl = "crt.jpg",
                       Author = new Author{Id = 2}
                   },
                   new Book
                   {
                       Id=3 , Title="Python Programming" , 
                       Description="No Data",
                       ImageUrl = "pic.jpg",
                       Author = new Author{Id = 2}
                   },
                };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book newbook)
        {
            var book = Find(id);

            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Author = newbook.Author;
            book.ImageUrl = newbook.ImageUrl;
        }
    }
}
