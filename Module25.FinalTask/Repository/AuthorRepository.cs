using Module25.FinalTask.Checks;
using Module25.FinalTask.Entities;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Repository
{
    public class AuthorRepository
    {
        private AppContext db;
        public AuthorRepository(AppContext db) { this.db = db; }

        public void GetAllAuthors()
        {
            var authors = db.Authors.ToList();
            if (authors.Count == 0)
            {
                AlertMessage.Show("В базе отсутствуют авторы.");
                return;
            }

            int currentAuthor = 1;
            foreach (var author in authors)
            {
                Console.WriteLine("Автор #{0}", currentAuthor);
                ShowAuthorData(author);
                currentAuthor++;
            }
        }

        private void ShowAuthorData(Author author)
        {
            Console.WriteLine("Информация об авторе:");
            Console.WriteLine("ID: {0}", author.Id);
            Console.WriteLine("Имя: {0}", author.Name);
        }

        public Author GetAuthor()
        {
            var stringId = QuestionMessage.Question("Введите ID автора:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return GetAuthor();
            }

            Author author = GetAuthor(id);
            return author;
        }

        public Author GetAuthor(int id)
        {
            var Query =
            from author in db.Authors
            where author.Id == id
            select author;

            Author foundAuthor = Query.FirstOrDefault() ?? new Author();

            return foundAuthor;
        }

        public void AddAuthor(AppContext db)
        {
            Author author = new();

            author.Name = QuestionMessage.Question("Введите имя автора:");

            db.Authors.Add(author);
            db.SaveChanges();

            SuccessMessage.Show("Автор успешно добавлен!");
        }
    }
}
