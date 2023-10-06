using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Repositories.Interfaces
{
    public interface IUserIdentityRepository
    {
        Task<object> GetUserByEmailAsync(string email);
        Task<bool> ExistsAsync(string email);
    }
}