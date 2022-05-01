using BackAlleyCinema.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Models
{
    public class Movie : IMovie
    {


        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageTo64 { get; set; }
        public string TrailerUrl { get; set; }
        public string Poster { get; set; }

        public DateTime? ReleaseDate { get; set; }

        

        public List<Schedule> Schedules { get; set; } = new List<Schedule> ();


    }
}
