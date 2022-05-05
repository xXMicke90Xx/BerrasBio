using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace BackAlleyCinema.Services
{
    public class AddObjects
    {
        private readonly CinemaDbContext _context;
        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
        public AddObjects(CinemaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Knyter Samman borden med film, salong och när den ska visas
        /// </summary>
        /// <param name="saloonId"></param>
        /// <returns></returns>
        private List<Schedule> JoinTablesWithShowTimes(int saloonId)
        {
            Random random = new Random();
            List<Schedule> ShowTimes = new List<Schedule>();
            int moviesToShow = random.Next(1, 9);
            for (TimeOnly i = TimeOnly.Parse("01:30:00"); i < TimeOnly.Parse("22:30:00"); i = i.AddHours(1.5))
            {
                ShowTimes.Add(new Schedule
                {

                    MovieId = moviesToShow,
                    SaloonId = saloonId,
                    ViewsId = DateTime.Parse("20-5-2022 " + i, culture),
                    TicketsSold = 0

                });
                if (moviesToShow > 1)
                {
                    moviesToShow--;
                }
                else
                {
                    moviesToShow = 8;
                }
            }

            return ShowTimes;
        }

        /// <summary>
        /// Fyller databasen med data
        /// </summary>
        /// <returns></returns>
        public async Task FillDataBaseWithMovies()
        {
            
            serializerSettings.Culture = new CultureInfo("sv-SE");
            Encoding unicode = Encoding.GetEncoding("ISO-8859-1");

            string movieObjects = File.ReadAllText("Movies.json", unicode);
            var movies = JsonConvert.DeserializeObject<List<Movie>>(movieObjects, serializerSettings);
                                
            string saloonObjects = File.ReadAllText("Saloon.json");
            var saloon = JsonConvert.DeserializeObject<List<Saloon>>(saloonObjects);


            List<Schedule> ShowTimes = JoinTablesWithShowTimes(1);
            ShowTimes.AddRange(JoinTablesWithShowTimes(2));
            

       
        
            
            

            await _context.Movies.AddRangeAsync(movies);
            await _context.SaveChangesAsync();
            await _context.Saloons.AddRangeAsync(saloon);
            await _context.SaveChangesAsync();
            await _context.Schedules.AddRangeAsync(ShowTimes);
            await _context.SaveChangesAsync();

        }




    }

}

