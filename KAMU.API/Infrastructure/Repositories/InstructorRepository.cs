using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;
using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Repositories
{
    /// <summary>
    /// Manages the activities of an instructor
    /// </summary>
    public class InstructorRepository : Repository<Instructor>, IUserInstructorRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in a database</param>
        public InstructorRepository(ISession session) : base(session)
        {
        }
    }
}
