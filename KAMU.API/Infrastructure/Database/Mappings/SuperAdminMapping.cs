using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    public class SuperAdminMapping : BaseEntityMapping<SuperAdmin>
    {
        public SuperAdminMapping()
        {
            Table("SuperAdmins");
            Map(s => s.Email).Not.Nullable();
            Map(s => s.FirstName).Not.Nullable();
            Map(s => s.LastName).Not.Nullable();
            Map(s => s.UserName).Not.Nullable();
            Map(s => s.PasswordHash).Not.Nullable();
            HasMany(s => s.LearningPaths);
            References(s => s.Organisation).Cascade.SaveUpdate();
        }
    }
}
