using Module25.FinalTask.Config;
using Module25.FinalTask.Entities;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Repository
{
    public class BookRepository
    {
        private AppContext db;
        public BookRepository(AppContext db)
        {
            this.db = db;
        }

        public void GetBookByID()
        {
            var stringId = QuestionMessage.Question("Введите ID книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким ID в базе не найдена.");
                return;
            }

            ShowBookData(book);
        }

        public void GetAllBooks()
        {
            var books = db.Books.ToList();
            if (books.Count == 0)
            {
                AlertMessage.Show("В базе отсутствуют книги.");
                return;
            }

            int currentBook = 1;
            foreach (var book in books)
            {
                Console.WriteLine("Книга #{0}", currentBook);
                ShowBookData(book);
                currentBook++;
            }
        }

        private void ShowBookData(Book book)
        {
            Console.WriteLine("Информация о книге:");
            Console.WriteLine("ID: {0}", book.Id);
            Console.WriteLine("Наименование: {0}", book.Title);
            Console.WriteLine("Год издания: {0}", book.ReleaseYear);
            Console.WriteLine("ID жанра книги: {0}", book.GenreId);
            Console.WriteLine("ID автора книги: {0}", book.AuthorID);
        }

        public Book GetBook(int id)
        {
            var Query =
            from book in db.Books
            where book.Id == id
            select book;

            Book foundbook = Query.FirstOrDefault() ?? new Book();

            return foundbook;
        }

        public Book GetBook()
        {
            var stringId = QuestionMessage.Question("Введите ID книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return GetBook();
            }

            Book book = GetBook(id);

            return book;
        }

        private void UpdateBookData(ref Book book)
        {
            AuthorRepository authorRepository = new(db);
            GenreRepository genreRepository = new(db);

            book.Title = QuestionMessage.Question("Введите наименование книги:");

            int year;

            int.TryParse(QuestionMessage.Question("Введите год издания книги:"), out year);
            book.ReleaseYear = year;

            book.Author = authorRepository.GetAuthor();
            book.AuthorID = book.Author.Id;
            book.Genre = genreRepository.GetGenre();
            book.GenreId = book.Genre.Id;

            db.SaveChanges();
            SuccessMessage.Show("Данные успешно обновлены!");
        }

        public void AddBook()
        {
            AuthorRepository authorRepository = new(db);
            GenreRepository genreRepository = new(db);

            Book book = new Book();

            book.Title = QuestionMessage.Question("Введите наименование книги:");

            int year;
            int.TryParse(QuestionMessage.Question("Введите год издания книги:"), out year);
            book.ReleaseYear = year;

            book.Author = authorRepository.GetAuthor();
            book.AuthorID = book.Author.Id;
            book.Genre = genreRepository.GetGenre();
            book.GenreId = book.Genre.Id;

            db.Books.Add(book);
            db.SaveChanges();

            SuccessMessage.Show("Книга успешно добавлена!");
        }

        public void UpdateBook()
        {
            var stringId = QuestionMessage.Question("Введите ID книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким ID в базе не найдена.");
                return;
            }

            UpdateBookData(ref book);
        }

        public void RemoveBook()
        {
            var stringId = QuestionMessage.Question("Введите ID книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким ID в базе не найдена.");
                return;
            }

            db.Books.Remove(book);
            db.SaveChanges();

            SuccessMessage.Show("Книга успешно удалена!");
        }

        public void IssueBookToUser()
        {
            var stringId = QuestionMessage.Question("Введите ID книги:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            Book book = GetBook(id);
            if (book.Id == 0)
            {
                AlertMessage.Show("Книга с таким ID в базе не найдена.");
                return;
            }

            UserRepository userRepository = new(db);
            User user = userRepository.GetUser();

            if (user.Id == 0)
            {
                AlertMessage.Show("Пользователь с таким ID в базе не найден.");
                return;
            }

            InfoBook infoBook = new();
            infoBook.User = user;
            infoBook.Book = book;

            db.InfoBook.Add(infoBook);
            db.SaveChanges();

            SuccessMessage.Show("Книга успешно выдана пользователю!");
        }
    }
}
