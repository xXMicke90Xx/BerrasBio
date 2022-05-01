namespace BackAlleyCinema.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync (T entity);

        Task <T> GetAsync ();

        Task<List<T>> GetAllAsync ();
        Task<T> UpdateAsync (T entity);
        Task DeleteAsync (T entity);
        Task DeleteAsync (int id);



    }
}
