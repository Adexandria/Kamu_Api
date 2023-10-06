using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;

namespace KAMU.API.Infrastructure.Repositories
{
    public class StudentRepository : Repository, IStudentRepository
    {
        public StudentRepository(NHibernate.ISession session) : base(session)
        {
        }

        public async Task AddAsync(Student entity)
        {
           await _session.SaveOrUpdateAsync(entity);
        }

        public async Task DeleteAsync(Student entity)
        {
           await _session.DeleteAsync(entity);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _session.Query<Student>().AnyAsync(s => s.Email.ToLower() == email.ToLower());
        }

        public async Task<Student> GetUserByEmailAsync(string email)
        {
            return await _session.Query<Student>().Where(s=>s.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
           await _session.UpdateAsync(entity);
        }
    }
}
