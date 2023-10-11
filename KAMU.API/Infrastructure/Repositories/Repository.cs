using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using ISession = NHibernate.ISession;
namespace KAMU.API.Infrastructure.Repositories
{
    /// <summary>
    /// Manages the activities of all domain models.
    /// </summary>
    /// <typeparam name="T">Source type</typeparam>
    public class Repository<T> : IRepository<T> where T:IEntity
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in a database</param>
        public Repository(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Adds source type to database
        /// </summary>
        /// <param name="entity">Source object</param>
        public virtual async Task AddAsync(T entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        /// <summary>
        /// Updates source type in database
        /// </summary>
        /// <param name="entity">Source object</param>
        public virtual async Task UpdateAsync(T entity)
        {
            await _session.UpdateAsync(entity);
        }

        /// <summary>
        /// Deletes source type in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(T entity)
        {
            await _session.DeleteAsync(entity);
        }

        /// <summary>
        /// Manages the tansactions in the database
        /// </summary>
        protected readonly ISession _session;
    }
}
