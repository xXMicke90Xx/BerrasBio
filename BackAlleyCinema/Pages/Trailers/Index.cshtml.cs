using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackAlleyCinema.Pages.Trailers
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string URL { get; set; } 
        public void OnGet(Dictionary<string, string> url)
        {
            URL = url.Values.First();
        }
    }
}
