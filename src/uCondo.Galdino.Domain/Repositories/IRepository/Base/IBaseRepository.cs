namespace uCondo.Galdino.Domain.Repositories.IRepository.Base;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    Task AddOrUpdateAsync(TEntity entity);
}