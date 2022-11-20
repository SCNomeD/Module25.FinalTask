using Module25.FinalTask.Repository;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Views
{
    public class BookView
    {
        public BookRepository BookRepository { get; set; }
        public GenreRepository GenreRepository { get; set; }
        public AuthorRepository AuthorRepository { get; set; }

        public void Show(AppContext db)
        {
            BookRepository = new BookRepository(db);
            GenreRepository = new GenreRepository(db);
            AuthorRepository = new AuthorRepository(db);

            while (true)
            {
                Console.WriteLine("\nРабота с книгами:");
                Console.WriteLine("Для получения списка имеющихся авторов - введите \"1\"");
                Console.WriteLine("Для получения списка имеющихся жанров - введите \"2\"");
                Console.WriteLine("Для получения списка имеющихся книг - введите \"3\"");
                Console.WriteLine("Для добавления нового автора - введите \"4\"");
                Console.WriteLine("Для добавления нового жанра - введите \"5\"");
                Console.WriteLine("Для добавления новой книги - введите \"6\"");
                Console.WriteLine("Для удаления книги - введите \"7\"");
                Console.WriteLine("Для получения информации о книге по ID - введите \"8\"");
                Console.WriteLine("Для изменения данных существующей книги - введите \"9\"");
                Console.WriteLine("Для выдачи книги пользователю - введите \"10\"");
                Console.WriteLine("\nДля возврата в предыдущее меню - введите \"0\"");

                string key = Console.ReadLine();

                if (key == "0") break;
                switch (key)
                {
                    case "1":
                        {
                            AuthorRepository.GetAllAuthors();
                            break;
                        }

                    case "2":
                        {
                            GenreRepository.GetAllGenres();
                            break;
                        }

                    case "3":
                        {
                            BookRepository.GetAllBooks();
                            break;
                        }

                    case "4":
                        {
                            AuthorRepository.AddAuthor(db);
                            break;
                        }

                    case "5":
                        {
                            GenreRepository.AddGenre(db);
                            break;
                        }

                    case "6":
                        {
                            BookRepository.AddBook();
                            break;
                        }

                    case "7":
                        {
                            BookRepository.RemoveBook();
                            break;
                        }

                    case "8":
                        {
                            BookRepository.GetBookByID();
                            break;
                        }

                    case "9":
                        {
                            BookRepository.UpdateBook();
                            break;
                        }

                    case "10":
                        {
                            BookRepository.IssueBookToUser();
                            break;
                        }
                }
            }
        }
    }
}
