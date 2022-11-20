using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Views
{
    public class MainView
    {
        public UserView UserInfoView { get; set; }
        public BookView BookInfoView { get; set; }
        public InfoView AnalyticsView { get; set; }
        public MainView()
        {
            UserInfoView = new();
            BookInfoView = new();
            AnalyticsView = new();
        }
        public void Show(AppContext db)
        {
            while (true)
            {
                Console.WriteLine("Введите команду:");
                Console.WriteLine("Для работы с пользователями - введите \"1\"");
                Console.WriteLine("Для работы с книгами - введите \"2\"");
                Console.WriteLine("Для работы с аналитической информацией - введите \"3\"");
                Console.WriteLine("\nДля выхода - введите \"0\"");

                string? key = Console.ReadLine();

                if (key == "0") break;
                switch (key)
                {
                    case "1":
                        {
                            UserInfoView.Show(db);
                            break;
                        }
                    case "2":
                        {
                            BookInfoView.Show(db);
                            break;
                        }
                    case "3":
                        {
                            AnalyticsView.Show(db);
                            break;
                        }
                }
            }
        }
    }
}
