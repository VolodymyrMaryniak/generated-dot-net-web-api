using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Data.Models;

namespace BookStore.WebApi.Data.Repositories.Implementation;

public class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();
    
    public async Task<TEntity?> FindAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }
    
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }
    
    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = new TEntity { Id = id };
        dbContext.Entry(entity).State = EntityState.Deleted;
        await dbContext.SaveChangesAsync();
    }
}
