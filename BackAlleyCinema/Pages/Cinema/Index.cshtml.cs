using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace BackAlleyCinema.Pages.Cinema
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {        
        public Saloon ChosenSaloon { get; set; }
        
        public Movie ChosenMovie { get; set; }       
        public Schedule ThisSchedule { get; set; }
        private CinemaDbContext _context { get; }
        public int Seat { get; set; }
        public int Price { get; set; }
        public int MovieId { get; set; }
        public int SaloonNr { get; set; }
        public string ViewsId { get; set; }

        public IActionResult OnGet(Dictionary<string, string> data)
        {
            ChosenMovie = _context.Movies.Where(x => x.Id == int.Parse(data["Movie"])).FirstOrDefault();
            ChosenSaloon = _context.Saloons.Where(x => x.Id == int.Parse(data["Saloon"])).FirstOrDefault();
            ThisSchedule = _context.Schedules
                .Where(x => x.Saloons.Id == ChosenSaloon.Id &&
                x.MovieId == ChosenMovie.Id &&
                x.ViewsId == DateTime.Parse(data["Time"])).FirstOrDefault();
            
            return Page();
        }

        public IndexModel(CinemaDbContext context)
        {
            _context = context;
        }
        public IActionResult OnPost()
        {

            for (int i = Seat; i < (Price / 100) + Seat; i++)
            {
                if (ThisSchedule.TakenSeats != null && ThisSchedule.TakenSeats.Contains(Seat.ToString()))
                {

                    return Page();
                }

            }

            return RedirectToPage("../Payment/Index", new Dictionary<string, string> { { "Movie", MovieId.ToString() }, { "Saloon", SaloonNr.ToString() }, { "Time", ViewsId.ToString() }, { "Price", Price.ToString() }, { "FirstSeat", Seat.ToString() } });
        }
        
    }
}
