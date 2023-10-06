using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate;

namespace KAMU.API.Infrastructure.Repositories
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        public UserIdentityRepository(NHibernate.ISession session)
        {
            _session = session;
        }
        public Task<bool> ExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetUserByEmailAsync(string email)
        {
            var studentQuery = _session.QueryOver<Student>().Where(s=>s.Email.ToLower() == email.ToLower());

            var superAdminQuery = _session.QueryOver<SuperAdmin>().Where(s => s.Email.ToLower() == email.ToLower());

            var instructorQuery = _session.QueryOver<Instructor>().Where(s => s.Email.ToLower() == email.ToLower());

            var x = _session.CreateMultiCriteria().Add("student", studentQuery).Add("instructor", instructorQuery).Add("superAdmin", superAdminQuery);

            var students = x.GetResult("student") as List<Student>;
            var superadmins = x.GetResult("superadmin") as List<SuperAdmin>;
            var instructors = x.GetResult("instructor") as List<Instructor>;

            if (students.Any())
            {
                return await Task.FromResult(students.FirstOrDefault());
            }
            else if(instructors.Any())
            {
                return instructors.FirstOrDefault();
            }else
            {
                return superadmins.FirstOrDefault();
            }
            return null;

        }

        protected NHibernate.ISession _session;
    }
}
