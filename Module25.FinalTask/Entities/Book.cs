namespace Module25.FinalTask.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public int? AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
