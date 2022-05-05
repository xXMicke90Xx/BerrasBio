using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using BackAlleyCinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace BackAlleyCinema.Pages
{
    public class IndexModel : PageModel
    {
        
        ClearoldTickets ClearoldTickets { get; set; }
        private CinemaDbContext _context { get; set; }

        private static MovieSorter _sorter { get; set; }

        private AddObjects addObjects { get; set; }

        [BindProperty]
        public List<Movie> movies { get; set; } = new List<Movie>();

        public IndexModel(CinemaDbContext context, MovieSorter sorter, AddObjects objects)
        {
           
            _context = context;
            _sorter = sorter;
            addObjects = objects;
        }
        

        public async Task OnGetAsync()
        {
            
            if (_context != null && _context.Movies.Count() > 0)
            {
                movies = _context.Movies.ToList();

                if (_context.Tickets.Count() > 0)
                {
                    ClearoldTickets = new ClearoldTickets(_context);
                    await ClearoldTickets.VoidTickets();
                }
            }
            else
            {
                try
                {
                   
                    await addObjects.FillDataBaseWithMovies();
                   
                    
                    movies = _context.Movies.ToList();
                    Redirect("Index");
                }
                catch (Exception ex)
                {
                    RedirectToPage("/Error", new {ex = ex});
                }
            }
            

        }

        
    }
}