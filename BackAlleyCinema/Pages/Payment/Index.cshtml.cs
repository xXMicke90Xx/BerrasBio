using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace BackAlleyCinema.Pages.Payment
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        public Saloon ChosenSaloon { get; set; }
        public int Price { get; set; }
        public Movie ChosenMovie { get; set; }
        public int FirstSeat { get; set; }
        public Schedule ThisSchedule { get; set; }
        private CinemaDbContext _context { get; }
        public Ticket Ticket { get; set; } = new Ticket();

        
        public void OnGet(Dictionary<string, string> data)
        {
            Price = int.Parse(data["Price"]);
            ChosenMovie = _context.Movies.Where(x => x.Id == int.Parse(data["Movie"])).FirstOrDefault();
            ChosenSaloon = _context.Saloons.Where(x => x.Id == int.Parse(data["Saloon"])).FirstOrDefault();
            ThisSchedule = _context.Schedules
                .Where(x => x.Saloons.Id == ChosenSaloon.Id &&
                x.MovieId == ChosenMovie.Id &&
                x.ViewsId == DateTime.Parse(data["Time"])).FirstOrDefault();
            FirstSeat = int.Parse(data["FirstSeat"]);
            Ticket = new Ticket();

        }

        public IndexModel(CinemaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            try
            {
                List<Ticket> tickets = new List<Ticket>();
                string seatsTaken = "";
                for (int i = FirstSeat; i < Price / 100 + FirstSeat; i++)
                {
                    tickets.Add(new Ticket
                    {
                        EMail = Ticket.EMail,
                        MovieStart = Ticket.MovieStart,
                        PurchasedTime = DateTime.Now,
                        PhoneNumber = Ticket.PhoneNumber,
                        SaloonNr = Ticket.SaloonNr,
                        MovieTitle = Ticket.MovieTitle,
                        Seat = i,
                    });
                    seatsTaken += i.ToString() + ",";
                }

                ThisSchedule = _context.Schedules
                    .Where(x => x.Saloons.SaloonNr == tickets[0].SaloonNr &&
                    x.Movies.Title == tickets[0].MovieTitle &&
                    x.ViewsId == tickets[0].MovieStart).FirstOrDefault();
                ThisSchedule.TakenSeats += seatsTaken;
                ThisSchedule.TicketsSold += tickets.Count();
                _context.Tickets.AddRange(tickets);
                _context.Schedules.Update(ThisSchedule);
                _context.SaveChanges();

                return RedirectToPage("../EndPage/Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Något gick fel, testa att ladda om sidan igen eller starta om från index igen!", ex);
            }
           

            //using (var smtp = new SmtpClient("smtp-mail.outlook.com"))
            //{

            //    smtp.Port = 587;
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.EnableSsl = true;
            //    smtp.Credentials = new System.Net.NetworkCredential("Micke.Handledning@hotmail.com", "M1ke1sthebest2", "smtp-mail.outlook.com");


            //    var msg = new MailMessage
            //    {
            //        Body = "Hellooooo Sexy Girl mmmm yeeeeaaaahhhh",
            //        Subject = "Test",
            //        From = new MailAddress("Micke.Handledning@hotmail.com"),

            //    };
            //    msg.To.Add("Micke.n90@hotmail.com");
            //    smtp.SendMailAsync(msg);
                


            //}
        }
    }
}
