namespace MoviesCatalog.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; set; }
        public List<FilmCategory> FilmCategories { get; set; }
    }
}
