using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;

namespace KAMU.API.Infrastructure.Repositories
{
    public class SuperAdminRepository : Repository, ISuperAdminRepository
    {
        public SuperAdminRepository(NHibernate.ISession session) : base(session)
        {
        }

        public async Task AddAsync(SuperAdmin entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task DeleteAsync(SuperAdmin entity)
        {
            await _session.DeleteAsync(entity);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _session.Query<SuperAdmin>().AnyAsync(s => s.Email.ToLower() == email.ToLower());
        }

        public async Task<SuperAdmin> GetUserByEmailAsync(string email)
        {
            return await _session.Query<SuperAdmin>().Where(s => s.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(SuperAdmin entity)
        {
            await _session.UpdateAsync(entity);
        }
    }
}
