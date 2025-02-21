using MovieService.src.MovieService.Domain.Entities;

namespace MovieService.src.MovieService.Infrastructure.Repositores.Abstraction
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> FindByFilter(Func<T, bool> predicate);
        Task<T>? GetByIdAsync(Guid id);
    }
}
