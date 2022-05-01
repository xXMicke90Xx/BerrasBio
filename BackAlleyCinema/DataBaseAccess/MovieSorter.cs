using BackAlleyCinema.Models;
using System.Globalization;

namespace BackAlleyCinema.DataBaseAccess
{
    public class MovieSorter
    {
        private readonly CinemaDbContext _context;

        public MovieSorter(CinemaDbContext context)
        {
            _context = context;
        }


        public List<Movie> SortByLatestRelease()
        {
            if (_context.Movies != null && _context.Movies.Count() > 0)
            {
                List<Movie> movies = new List<Movie>(); 

               
                foreach(var movie in _context.Movies)
                {
                    movies.Add(new Movie
                    {
                        Title = movie.Title.ToString(CultureInfo.GetCultureInfo("sv-SE")),
                        Description = movie.Description.ToString(CultureInfo.GetCultureInfo("sv-SE")),
                        ImageTo64 = movie.ImageTo64,
                        ReleaseDate = movie.ReleaseDate,
                        Poster = movie.Poster,
                        TrailerUrl = movie.TrailerUrl,

                    });
                }

                

                if (movies.Any())
                {
                    movies = movies.OrderByDescending(x => x.ReleaseDate).ToList(); 
                    return movies;
                }

                return null;
            }
            return null;
        }
    }
}
