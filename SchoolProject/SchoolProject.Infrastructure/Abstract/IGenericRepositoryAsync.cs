using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolProject.Infrastructure.Abstract
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T> GetByIdAsync(int id);
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
