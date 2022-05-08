using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using BackAlleyCinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace BackAlleyCinema.Pages.Payment
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        
        public int Price { get; set; }       
        public int FirstSeat { get; set; }

        public string MovieTitle { get; set; }
        public int SaloonNr { get; set; }
        public DateTime ViewStart { get; set; }

        private CinemaDbContext _context { get; }
        [ModelBinder]
        public Ticket Ticket { get; set; }

        
        public void OnGet(Dictionary<string, string> data)
        {
            Price = int.Parse(data["Price"]);
            var chosenMovie = _context.Movies.Where(x => x.Id == int.Parse(data["Movie"])).FirstOrDefault();           
            var chosenSaloon = _context.Saloons.Where(x => x.Id == int.Parse(data["Saloon"])).FirstOrDefault();
            var thisSchedule = _context.Schedules
                .Where(x => x.Saloons.Id == chosenSaloon.Id &&
                x.MovieId == chosenMovie.Id &&
                x.ViewsId == DateTime.Parse(data["Time"])).FirstOrDefault();
            FirstSeat = int.Parse(data["FirstSeat"]);
            

            MovieTitle = chosenMovie.Title.ToString();
            SaloonNr = chosenSaloon.SaloonNr;
            ViewStart = thisSchedule.ViewsId;

        }

        public IndexModel(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPost(Ticket ticket)
        {
            
                List<Ticket> tickets = new List<Ticket>();
                string seatsTaken = "";
                for (int i = FirstSeat; i < Price / 100 + FirstSeat; i++)  //Skapar biljetter för tittarna
                {
                    tickets.Add(new Ticket
                    {
                        EMail = Ticket.EMail,
                        MovieStart = Ticket.MovieStart,
                        PurchasedTime = DateTime.Now,
                        PhoneNumber = Ticket.PhoneNumber,
                        SaloonNr = Ticket.SaloonNr,
                        MovieTitle = Ticket.MovieTitle,
                        Seat = (i+1),
                        

                    });
                    seatsTaken += i.ToString() + ",";
                }

            var thisSchedule = _context.Schedules
                .Where(x => x.Saloons.SaloonNr == tickets[0].SaloonNr &&
                x.Movies.Title == tickets[0].MovieTitle &&
                x.ViewsId == tickets[0].MovieStart).FirstOrDefault();


            ModelState.Remove("MovieTitle");

            if (ModelState.IsValid == true)
            {
                try //Tyvärr buggig då authentication inte alltid vill. 
                {
                    await MailService.MailSender(Ticket.EMail, Ticket.MovieTitle, seatsTaken, Ticket.SaloonNr, Ticket.MovieStart.ToString());
                }
                finally
                {



                    thisSchedule.TakenSeats += seatsTaken;
                    thisSchedule.TicketsSold += tickets.Count();

                    await _context.Tickets.AddRangeAsync(tickets);
                    _context.Schedules.Update(thisSchedule);
                    await _context.SaveChangesAsync();
                }
                    return RedirectToPage("../EndPage/Index", new { id = thisSchedule.MovieId });
                
            }
            else
            {
                
                return RedirectToPage("../Payment/Index", new Dictionary<string, string> { { "Movie", thisSchedule.MovieId.ToString() }, { "Saloon", thisSchedule.SaloonId.ToString() }, { "Time", thisSchedule.ViewsId.ToString() }, { "Price", Price.ToString() }, { "FirstSeat", FirstSeat.ToString() } });


            }


            
            
        }
    }
}
