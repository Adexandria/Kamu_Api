using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    public class OrganisationMapping : BaseEntityMapping<Organisation>
    {
        public OrganisationMapping()
        {
            Table("Organisations");
            HasMany(s => s.Instructors);
            HasMany(s => s.SuperAdmins);
            HasMany(s => s.Students);
        }
    }
}
