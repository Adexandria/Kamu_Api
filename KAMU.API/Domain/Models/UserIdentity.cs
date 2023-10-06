using Microsoft.AspNetCore.Identity;

namespace KAMU.API.Domain.Models
{
    public class UserIdentity : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
