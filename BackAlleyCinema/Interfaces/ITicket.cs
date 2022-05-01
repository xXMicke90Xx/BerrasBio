using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Interfaces
{
    public interface ITicket
    {
        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime PurchasedTime { get; set; }
        public DateTime MovieStart { get; set; }
        public int SaloonNr { get; set; }
    }
}
