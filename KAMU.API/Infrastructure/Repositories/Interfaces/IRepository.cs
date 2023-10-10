using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Manages the activities of all domain models.
    /// </summary>
    /// <typeparam name="T">Source type</typeparam>
    public interface IRepository<T> where T: IEntity
    {
        /// <summary>
        /// Adds source type to database
        /// </summary>
        /// <param name="entity">Source object</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates source type in database
        /// </summary>
        /// <param name="entity">Source object</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes source type in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);
       
    }
}
