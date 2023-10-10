using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;

namespace KAMU.API.Infrastructure.Repositories
{
    /// <summary>
    /// Manages the activities of the student
    /// </summary>
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in a database</param>
        public StudentRepository(NHibernate.ISession session) : base(session)
        {
        }

    }
}
