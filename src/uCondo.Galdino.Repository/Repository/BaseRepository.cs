using Microsoft.EntityFrameworkCore;
using uCondo.Galdino.Domain.Entity.Base;
using uCondo.Galdino.Domain.Repositories.IRepository.Base;
using uCondo.Galdino.Repository.Repository.Context;

namespace uCondo.Galdino.Repository.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly uCondoContext context;
    protected DbSet<TEntity> DbSet;

    public BaseRepository(uCondoContext context)
    {
        this.context = context;
        DbSet = context.Set<TEntity>();
    }

    public void Dispose() => GC.SuppressFinalize(this);

    public async Task Add(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChanges();
    }

    public async Task<TEntity> GetByIdAsync(int id) => await DbSet.FindAsync(id);


    // public async Task<TEntity> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);
    

    public async Task<List<TEntity>> GetAllAsync()
    {
        var result = await DbSet.ToListAsync();
        return result;
    }

    public async Task Update(TEntity obj)
    {
        DbSet.Update(obj);
        await SaveChanges();
    }

    public async Task Remove(int id)
    {
        var remove = await GetByIdAsync(id);
        context.Remove(remove);
        await SaveChanges();
    }

    private async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(TEntity entity)
    {
        if (entity == null)
            return;

        if (string.IsNullOrEmpty(entity.Id.ToString()))
            await Add(entity);
        else
            await Update(entity);
    }
}