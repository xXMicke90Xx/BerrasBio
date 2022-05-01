using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackAlleyCinema.Pages.MoviePages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly CinemaDbContext _context;
        public int MenuChoice { get; set; } = 0;
        public List<Schedule> schedules { get; set; }
        public List<Saloon> Saloons { get; set; }
        string t = "test";
        public Movie ChosenMovie { get; set; }

        public IndexModel(CinemaDbContext context)
        {
            _context = context;
            
            
        }

        public void OnGet(Dictionary<string, string> title)
        {

            ChosenMovie = _context.Movies.Where(x => x.Title == title.Values.First()).First();
            schedules = _context.Schedules.Where(x => x.MovieId == ChosenMovie.Id).ToList();
            Saloons = _context.Saloons.ToList();
        }
        public IActionResult MyTest()
        {

            return RedirectToPage("/Cinema", t);
        }
       
    }
}
