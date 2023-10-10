using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Utilities;
using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Repositories
{
    /// <summary>
    /// Manages the authentication activities of all users
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in the database</param>
        public UserRepository(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Checks if the email exists in the super admin, student and instructor tables
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <returns>A boolean value</returns>
        public bool IsEmailExists(string email)
        {
            var students = _session.QueryOver<Student>().Where(x => x.Email == email).Future<Student>();

            var superAdmins = _session.QueryOver<SuperAdmin>().Where(s => s.Email == email).Future<SuperAdmin>();

            var instructors = _session.QueryOver<Instructor>().Where(s => s.Email == email).Future<Instructor>();

            if (students.Any())
            {
                return true;
            }
            else if (instructors.Any())
            {
                return true;
            }
            else if (superAdmins.Any())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the user details by email
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>User details</returns>
        public UserDetails GetUserDetailsByEmail(string email)
        {
            var students = _session.QueryOver<Student>().Where(s=>s.Email == email).Future();

            var superAdmins = _session.QueryOver<SuperAdmin>().Where(s => s.Email == email).Future();

            var instructors = _session.QueryOver<Instructor>().Where(s => s.Email == email).Future();

            if (students.Any())
            {
                return new UserDetails(students.FirstOrDefault(),Role.Student);
            }
            else if(instructors.Any())
            {
                return new UserDetails(instructors.FirstOrDefault(),Role.Instructor);
            }
            else if(superAdmins.Any())
            {
                return new UserDetails(superAdmins.FirstOrDefault(),Role.SuperAdmin);
            }
            return null;
        }

        /// <summary>
        /// Manages the transaction in the database
        /// </summary>
        protected ISession _session;
    }
}
