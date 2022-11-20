using Module25.FinalTask.Checks;
using Module25.FinalTask.Entities;
using AppContext = Module25.FinalTask.DB.AppContext;

namespace Module25.FinalTask.Repository
{
    public class GenreRepository
    {
        private AppContext db;
        public GenreRepository(AppContext db) { this.db = db; }

        public void GetAllGenres()
        {
            var genres = db.Genres.ToList();
            if (genres.Count == 0)
            {
                AlertMessage.Show("В базе отсутствуют жанры.");
                return;
            }

            int currentGenre = 1;
            foreach (var genre in genres)
            {
                Console.WriteLine("Жанр #{0}", currentGenre);
                ShowGenreData(genre);
                currentGenre++;
            }
        }

        private void ShowGenreData(Genre genre)
        {
            Console.WriteLine("Информация о жанре:");
            Console.WriteLine("ID: {0}", genre.Id);
            Console.WriteLine("Наименование: {0}", genre.Name);
        }

        public Genre GetGenre()
        {
            var stringId = QuestionMessage.Question("Введите ID жанра:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return new Genre();
            }

            Genre genre = GetGenre(id);
            return genre;
        }

        public Genre GetGenre(int id)
        {
            var Query =
            from genre in db.Genres
            where genre.Id == id
            select genre;

            Genre foundGenre = Query.FirstOrDefault() ?? new Genre();

            return foundGenre;
        }

        public void AddGenre(AppContext db)
        {
            Genre genre = new();

            genre.Name = QuestionMessage.Question("Введите наименование жанра:");

            db.Genres.Add(genre);
            db.SaveChanges();

            SuccessMessage.Show("Жанр успешно добавлен!");
        }
    }
}
