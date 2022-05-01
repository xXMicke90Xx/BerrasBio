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
        

        public void OnGetAsync()
        {
            
            if (_context != null && _context.Movies.Count() > 0)
            {
                movies = _context.Movies.ToList();
            }
            else
            {
                try
                {
                   
                    addObjects.FillDataBaseWithMovies();
                   
                    
                    movies = _sorter.SortByLatestRelease();
                    Redirect("Index");
                }
                catch
                {
                    Redirect("/Error");
                }
            }
            

        }

        
    }
}