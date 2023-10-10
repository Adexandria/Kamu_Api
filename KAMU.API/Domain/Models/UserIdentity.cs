using Microsoft.AspNetCore.Identity;

namespace KAMU.API.Domain.Models
{
    public class UserIdentity : IdentityUser<Guid>, IEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
