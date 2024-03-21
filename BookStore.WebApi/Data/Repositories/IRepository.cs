using BookStore.WebApi.Data.Models;

namespace BookStore.WebApi.Data.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity, new()
{
    Task<TEntity?> FindAsync(int id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id); 
}
