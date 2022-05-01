using BackAlleyCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace BackAlleyCinema.DataBaseAccess
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Kompositnyckel
            modelBuilder.Entity<Schedule>()
                .HasKey(t => new { t.MovieId, t.SaloonId, t.ViewsId });

            //Relationer
            modelBuilder.Entity<Schedule>()
                .HasOne(b => b.Movies)
                .WithMany(st => st.Schedules)
                .HasForeignKey(b => b.MovieId);

            
                
        }
    }

    
}
