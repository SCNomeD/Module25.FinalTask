using Module25.FinalTask.Repository;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Views
{
    public class InfoView
    {
        public InfoRepository InfoRepository { get; set; }

        public void Show(AppContext db)
        {
            InfoRepository = new InfoRepository(db);
            while (true)
            {
                Console.WriteLine("\nРабота с аналитической информацией:");
                Console.WriteLine("Для получения списка книг определенного жанра и вышедших между определенными годами - введите \"1\"");
                Console.WriteLine("Для получения количества книг определенного автора в базе - введите \"2\"");
                Console.WriteLine("Для получения количества книг определенного жанра в базе - введите \"3\"");
                Console.WriteLine("Для проверки наличия книги определенного автора и с определенным названием в базе - введите \"4\"");
                Console.WriteLine("Для проверки наличия книги по ее ID на руках у пользователя по его ID - введите \"5\"");
                Console.WriteLine("Для проверки количества книг на руках у пользователя - введите \"6\"");
                Console.WriteLine("Для получения информации о последней вышедшей книге - введите \"7\"");
                Console.WriteLine("Для получение списка всех книг, отсортированных в алфавитном порядке по названию - введите \"8\"");
                Console.WriteLine("Для получения списка всех книг, отсортированных в порядке убывания года их выхода - введите \"9\"");
                Console.WriteLine("\nДля возврата в предыдущее меню - введите \"0\"");

                string key = Console.ReadLine();

                if (key == "0") break;
                switch (key)
                {
                    case "1":
                        {
                            InfoRepository.ListBooksOverPeriod();
                            break;
                        }
                    case "2":
                        {
                            InfoRepository.GetBooksCountForAuthor();
                            break;
                        }

                    case "3":
                        {
                            InfoRepository.GetBooksCountForGenre();
                            break;
                        }

                    case "4":
                        {
                            InfoRepository.ThereIsABookInTheBase();
                            break;
                        }

                    case "5":
                        {
                            InfoRepository.UserHasBook();
                            break;
                        }

                    case "6":
                        {
                            InfoRepository.NumberOfBooksUser();
                            break;
                        }
                    case "7":
                        {
                            InfoRepository.LatestPublishedBook();
                            break;
                        }

                    case "8":
                        {
                            InfoRepository.GetBooksTitleAscending();
                            break;
                        }

                    case "9":
                        {
                            InfoRepository.GetBooksReleaseYearADescending();
                            break;
                        }
                }
            }
        }
    }
}
