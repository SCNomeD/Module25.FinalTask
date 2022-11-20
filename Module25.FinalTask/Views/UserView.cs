using Module25.FinalTask.Repository;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Views
{
    public class UserView
    {
        public UserRepository UserRepository { get; set; }

        public void Show(AppContext db)
        {
            UserRepository = new UserRepository(db);

            while (true)
            {
                Console.WriteLine("\nРабота с пользователями:");
                Console.WriteLine("Для получения информации о пользователе по ID - введите \"1\"");
                Console.WriteLine("Для получения списка имеющихся пользователей - введите \"2\"");
                Console.WriteLine("Для добавления нового пользователя - введите \"3\"");
                Console.WriteLine("Для изменения данных существующего пользователя - введите \"4\"");
                Console.WriteLine("Для удаления пользователя - введите \"5\"");
                Console.WriteLine("\nДля возврата в предыдущее меню - введите \"0\"");

                string key = Console.ReadLine();

                if (key == "0") break;
                switch (key)
                {
                    case "1":
                        {
                            UserRepository.GetUserByID();
                            break;
                        }
                    case "2":
                        {
                            UserRepository.GetAllUsers();
                            break;
                        }

                    case "3":
                        {
                            UserRepository.AddUser();
                            break;
                        }

                    case "4":
                        {
                            UserRepository.UpdateUserData();
                            break;
                        }

                    case "5":
                        {
                            UserRepository.RemoveUser();
                            break;
                        }
                }
            }
        }
    }
}
