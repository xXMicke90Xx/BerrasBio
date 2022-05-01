namespace BackAlleyCinema.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public List<string>? MovieGenres { get; set; } = new List<string>() {"Action", "Family", "Comedy", "Adventure"};
    }
}
