using Module25.FinalTask.Checks;
using Module25.FinalTask.Entities;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Repository
{
    public class InfoRepository
    {
        private AppContext db;
        private UserRepository userRepository;
        private BookRepository bookRepository;
        private AuthorRepository authorRepository;
        private GenreRepository genreRepository;

        public InfoRepository(AppContext db)
        {
            this.db = db;
            userRepository = new UserRepository(db);
            bookRepository = new BookRepository(db);
            authorRepository = new AuthorRepository(db);
            genreRepository = new GenreRepository(db);
        }

        public int GetBooksCount()
        {
            var Query =
            from book in db.Books
            select book;

            return Query.ToList().Count();
        }

        public void GetBooksCountForAuthor()
        {
            var stringId = QuestionMessage.Question("Введите ID автора:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Author author = authorRepository.GetAuthor(id);
            if (author.Id == 0)
            {
                AlertMessage.Show("Автор с таким ID в базе не найден.");
                return;
            }

            var Query =
            from book in db.Books
            where book.Author == author
            select book;

            SuccessMessage.Show("В базе имеется " + Query.Count().ToString() + " книг автора " + author.Name);
        }

        public void GetBooksCountForGenre()
        {
            var stringId = QuestionMessage.Question("Введите ID жанра:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Жанр с таким ID в базе не найден.");
                return;
            }

            var Query =
            from book in db.Books
            where book.Genre == genre
            select book;

            SuccessMessage.Show("В базе имеется " + Query.Count().ToString() + " жанра " + genre.Name);
        }

        public void GetBooksOfGenre()
        {
            var stringId = QuestionMessage.Question("Введите ID жанра:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Жанр с таким ID в базе не найден.");
                return;
            }

            var Query =
            from book in db.Books
            where book.Genre == genre
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void GetBooksOfGenreAndReleaseYear()
        {

            var stringId = QuestionMessage.Question("Введите ID жанра:");

            int id, releaseYear;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Жанр с таким ID в базе не найден.");
                return;
            }

            stringId = QuestionMessage.Question("Введите год выхода книги:");

            result = int.TryParse(stringId, out releaseYear);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            var Query =
            from book in db.Books
            where (book.Genre == genre) && (book.ReleaseYear == releaseYear)
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void ListBooksOverPeriod()
        {
            int id;
            var stringId = QuestionMessage.Question("Введите ID жанра:");

            bool result = int.TryParse(stringId, out id);

            Genre genre = genreRepository.GetGenre(id);
            if (genre.Id == 0)
            {
                AlertMessage.Show("Автор с таким ID в базе не найден.");
                return;
            }

            try
            {
                Console.WriteLine("Введите начальный год отчетного периода:");
                int date1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите конечный год отчетного периода:");
                int date2 = Convert.ToInt32(Console.ReadLine());

                var books = db.Books.Where(a => a.Genre == genre).Where(a => a.ReleaseYear >= date1 & a.ReleaseYear <= date2).ToList();

                if (books.Count == 0)
                {
                    Console.WriteLine("Список пуст");
                }
                else
                {
                    int currentbook = 1;
                    foreach (var book in books)
                    {
                        Console.WriteLine("Книга #{0}", currentbook);
                        Console.WriteLine(book.Title + "; Год опубликования: " + book.ReleaseYear);
                        currentbook++;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Введены некорректные данные");
            }
        }

        public void GetBooksTitleAscending()
        {
            var Query =
            from book in db.Books
            orderby book.Title
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void GetBooksTitleDescending()
        {
            var Query =
            from book in db.Books
            orderby book.Title descending
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void GetBooksReleaseYearAscending()
        {
            var Query =
            from book in db.Books
            orderby book.ReleaseYear
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void GetBooksReleaseYearADescending()
        {
            var Query =
            from book in db.Books
            orderby book.ReleaseYear descending
            select book;

            foreach (var book in Query)
            {
                SuccessMessage.Show(book.Title);
            }
        }

        public void ThereIsABookInTheBase()
        {
            var stringId = QuestionMessage.Question("Введите ID автора:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Author author = authorRepository.GetAuthor(id);
            if (author.Id == 0)
            {
                AlertMessage.Show("Автор с таким ID в базе не найден.");
                return;
            }

            var bookTitle = QuestionMessage.Question("Введите наименование книги:");

            var Query =
            from book in db.Books
            where (book.Author == author) && (book.Title == bookTitle)
            select book;

            if (Query.Count() > 0) { SuccessMessage.Show("Такая книга есть в базе."); return; }

            AlertMessage.Show("Такая книга в базе отсутствует.");
        }

        public void UserHasBook()
        {
            User user = userRepository.GetUser();
            Book book = bookRepository.GetBook();

            var Query =
            from record in db.InfoBook
            where (record.User == user) && (record.Book == book)
            select record;

            if (Query.Count() > 0) { SuccessMessage.Show("Книга на руках у пользователя."); return; }

            SuccessMessage.Show("Книги нет на руках у пользователя.");
        }

        public void NumberOfBooksUser()
        {
            User user = userRepository.GetUser();

            var Query =
            from record in db.InfoBook
            where record.User == user
            select record;

            SuccessMessage.Show("Книг на руках у пользователя: " + Query.Count().ToString());
        }

        public void LatestPublishedBook()
        {
            var Query =
            from book in db.Books
            orderby book.ReleaseYear descending
            select book;

            var ourBook = Query.FirstOrDefault();
            SuccessMessage.Show("Последняя вышедшая книга: " + ourBook.Title + "; год выхода: " + ourBook.ReleaseYear.ToString());
        }
    }
}
