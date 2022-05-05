
using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Models
{
    public class Ticket 
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Du måste ange en giltig Mail, biljetterna kommer komma där!")]
        public string EMail { get; set; }
        [Required]
        [Phone(ErrorMessage = "Skriv bara något som kan tänkas funka, ta ditt nummer och byt 3 siffror")]
        public string PhoneNumber { get; set; }
        [Required]

        public DateTime PurchasedTime { get; set; }
        [Required]
        public DateTime MovieStart { get; set; }
        [Required]
        
        public string MovieTitle { get; set; }
        [Required]
        public int Seat { get; set; }

        [Required]
        public int SaloonNr { get; set; }


      
    }
}
