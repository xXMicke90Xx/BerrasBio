using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackAlleyCinema.Pages.Cinema
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        
        public Saloon ChosenSaloon { get; set; }

        public Movie ChosenMovie { get; set; }
        
        public Schedule ThisSchedule { get; set; }
        private CinemaDbContext _context { get; }

        public void OnGet(Dictionary<string, string> data)
        {
            ChosenMovie = _context.Movies.Where(x => x.Id == int.Parse(data["Movie"])).FirstOrDefault();
            ChosenSaloon = _context.Saloons.Where(x => x.Id == int.Parse(data["Saloon"])).FirstOrDefault();
            ThisSchedule = _context.Schedules
                .Where(x => x.Saloons.Id == ChosenSaloon.Id &&
                x.MovieId == ChosenMovie.Id &&
                x.ViewsId == DateTime.Parse(data["Time"])).FirstOrDefault();  
        }

        public IndexModel(CinemaDbContext context)
        {
            _context = context;
        }
        public IActionResult OnPost(Dictionary<string, string> data)
        {
            return RedirectToPage("../Index");
        }
    }
}
