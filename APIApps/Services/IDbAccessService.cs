namespace APIApps.Services
{
    public interface IDbAccessService<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id,TEntity entity);
        Task<bool> DeleteAsync(TPk id);
    }
}
