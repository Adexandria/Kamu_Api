using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;

namespace KAMU.API.Infrastructure.Repositories
{
    public class InstructorRepository : Repository, IUserInstructorRepository
    {
        public InstructorRepository(NHibernate.ISession session) : base(session)
        {
        }

        public async Task AddAsync(Instructor entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async  Task DeleteAsync(Instructor entity)
        {
            await _session.DeleteAsync(entity);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _session.Query<Instructor>().AnyAsync(s => s.Email.ToLower() == email.ToLower());
        }

        public async Task<Instructor> GetUserByEmailAsync(string email)
        {
            return await _session.Query<Instructor>().Where(s => s.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Instructor entity)
        {
            await _session.UpdateAsync(entity);
        }
    }
}
