namespace MoviesCatalog.Models
{
    public class FilmCategory
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Movie Film { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
