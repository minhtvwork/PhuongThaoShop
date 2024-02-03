namespace PTS.Host.Repository.IRepository
{
     public interface IAllRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetPagedAsync(int page, int pageSize);
        Task<int> CountAsync();
    }
}
