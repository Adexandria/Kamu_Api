using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Extensions;

namespace KAMU.API.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<ActionResponseResult> CommitAsync();
    }
}
