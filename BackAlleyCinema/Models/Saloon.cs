using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Models
{
    public class Saloon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SaloonNr { get; set; }
        [Required]
        public int MaxSeats { get; set; } = 50;
        [Required]
        public int AvailableSeats { get; set; }

        

        


    }
}
