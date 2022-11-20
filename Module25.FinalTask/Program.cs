using Module25.FinalTask.Entities;
using Module25.FinalTask.Views;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask
{
    class Program
    {
        public static MainView mainView;
        static void Main(string[] args)
        {
            MainView mainView = new MainView();

            using (var db = new AppContext())
            {
                #region Для теста с заранее заполнеными данными
                var user1 = new User { Name = "Владимир", Email = "vladimir@gmail.com" };
                var user2 = new User { Name = "Анна", Email = "anna@gmail.com" };
                var user3 = new User { Name = "Антон", Email = "anton@gmail.com" };

                var author1 = new Author { Name = "Лермонтов М.Ю." };
                var author2 = new Author { Name = "Мартин Р.Р." };
                var author3 = new Author { Name = "Чехов А.П." };

                var genre1 = new Genre { Name = "Классика" };
                var genre2 = new Genre { Name = "Фэнтези" };
                var genre3 = new Genre { Name = "Научная фантастика" };

                var book1 = new Book { Title = "Герой нашего времени", ReleaseYear = 1840, Author = author1, Genre = genre1 };
                var book2 = new Book { Title = "Игра престолов", ReleaseYear = 1996, Author = author2, Genre = genre2 };
                var book3 = new Book { Title = "Путешествие Тафа", ReleaseYear = 1986, Author = author2, Genre = genre3 };
                var book4 = new Book { Title = "Вишнёвый сад", ReleaseYear = 1904, Author = author3, Genre = genre1 };

                db.Users.AddRange(user1, user2, user3);
                db.Books.AddRange(book1, book2, book3, book4);
                db.Authors.AddRange(author1, author2, author3);
                db.Genres.AddRange(genre1, genre2, genre3);

                db.SaveChanges();
                #endregion

                mainView.Show(db);
            }
        }
    }
}
