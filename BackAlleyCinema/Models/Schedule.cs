using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Models
{
    public class Schedule
    {
        [Key]
        public DateTime ViewsId { get; set; }
        [Key]
        public int MovieId { get; set; }
        public Movie Movies { get; set; }
        [Key]
        public int SaloonId { get; set; }
        public Saloon Saloons { get; set; }

        public int TicketsSold { get; set; }

        public string TakenSeats { get; set; } = "";

        public int TicketsId { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
