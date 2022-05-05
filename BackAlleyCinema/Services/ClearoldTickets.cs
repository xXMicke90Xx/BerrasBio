using BackAlleyCinema.DataBaseAccess;

namespace BackAlleyCinema.Services
{
    public class ClearoldTickets
    {
        private readonly CinemaDbContext _context;

        public ClearoldTickets(CinemaDbContext context)
        {
            _context = context;
        }


        public async Task VoidTickets()
        {
            var tickets = _context.Tickets.ToList();


            foreach (var item in tickets)
            {
                if (item.MovieStart.AddDays(1) < item.MovieStart)
                {
                    _context.Remove(item);

                    var scedules = _context.Schedules.Where(x => x.ViewsId == item.MovieStart && x.Movies.Title == item.MovieTitle).FirstOrDefault();

                    List<string> seats = scedules.TakenSeats.Split(",").ToList();

                    for (int i = 0; i < seats.Count; i++)
                    {
                        if (seats[i] == item.Seat.ToString())
                        {
                            seats.RemoveAt(i);
                            break;
                        }
                    }
                    string newSeats = "";
                    foreach (var seat in seats)
                        newSeats += seat + ",";
                    scedules.TakenSeats = newSeats;
                    scedules.TicketsSold -= 1;
                    _context.Schedules.Update(scedules);



                }


            }



            await _context.SaveChangesAsync();

        }

    }
}
