using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Data.Models;

namespace BookStore.WebApi.Data.Repositories.Implementation;

public class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();
    
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await DbSet.Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();
    }
    
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Added;
        await dbContext.SaveChangesAsync();
        return entity;
    }
    
    public async Task UpdateAsync(TEntity entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = new TEntity { Id = id };
        dbContext.Entry(entity).State = EntityState.Deleted;
        await dbContext.SaveChangesAsync();
    }
}
