using Microsoft.EntityFrameworkCore;
using MovieService.src.MovieService.Domain.Entities;
using MovieService.src.MovieService.Infrastructure.Data;
using MovieService.src.MovieService.Infrastructure.Repositores.Abstraction;

namespace MovieService.src.MovieService.Infrastructure.Repositores
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            T entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _appDbContext.SaveChangesAsync();
            }
            {
                throw new ArgumentException($"Item with id {id} does not exist");
            }
        }

        public IEnumerable<T> FindByFilter(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T>? GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
