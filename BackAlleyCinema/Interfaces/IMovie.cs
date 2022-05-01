using System.ComponentModel.DataAnnotations;

namespace BackAlleyCinema.Interfaces
{
    public interface IMovie
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageTo64 { get; set; }

      

     

       


    }
}
