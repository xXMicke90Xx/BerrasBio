using BackAlleyCinema.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Models
{
    public class Ticket : ITicket
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]

        public DateTime PurchasedTime { get; set; }
        [Required]
        public DateTime MovieStart { get; set; }

       
        public int SaloonNr { get; set; }
    }
}
