using BackAlleyCinema.DataBaseAccess;
using BackAlleyCinema.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackAlleyCinema.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
       private readonly CinemaDbContext _context;

        public Repository(CinemaDbContext context)
        {
            _context = context;
        }

       

        public async Task CreateAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().AsNoTracking().ToListAsync();
            
        }

        public async Task<T> GetAsync(T entity)
        {
            return await _context.Set<T>().FindAsync(entity);
        }

        public Task<T> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            await DeleteAsync(entity);
        }

        Task<T> IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
