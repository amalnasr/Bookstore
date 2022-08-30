namespace Bookstore.Models.Repositories
{
    public class AuthorDbReposotory : IBookstoreRepository<Author>
    {
        IList<Author> authors;
        public AuthorDbReposotory()
        {
            authors = new List<Author>
            {
              new Author {Id = 1 , FullName ="Amal Nasr"},
              new Author {Id = 2 , FullName ="Aseel Omer"},
              new Author {Id = 3 , FullName ="Eleen Omer"},
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(a => a.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
        }
    }
    
    
}
