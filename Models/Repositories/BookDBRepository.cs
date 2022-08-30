using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bookstore.Models.Repositories
{
    public class BookDbRepository : IBookstoreRepository<Book>
    {
        BookstoreDbContext db;
        public BookDbRepository(BookstoreDbContext _db)
        {
            db = _db;
        }
        public void Add(Book entity)
            {
                
                db.Books.Add(entity);
                db.SaveChanges();
            }

            public void Delete(int id)
            {
                var book = Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
            }

            public Book Find(int id)
            {
                var book = db.Books.SingleOrDefault(b => b.Id == id);
                return book;
            }

            public IList<Book> List()
            {
                return db.Books.ToList();
            }

            public void Update(int id, Book newbook)
            {
                db.Books.Update(newbook);
                db.SaveChanges();
            }
        }
    }

