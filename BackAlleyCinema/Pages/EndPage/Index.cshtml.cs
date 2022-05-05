using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackAlleyCinema.Pages.EndPage
{
    public class IndexModel : PageModel
    {
        private readonly CinemaDbContext _context;

        public Movie Movie { get; set; }

        public IndexModel(CinemaDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            Movie = _context.Movies.Find(id);
        }
    }
}
