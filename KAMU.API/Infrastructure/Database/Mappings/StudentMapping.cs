using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    public class StudentMapping : BaseEntityMapping<Student>
    {
        public StudentMapping()
        {
            Table("Students");
            Map(s => s.Email).Not.Nullable();
            Map(s => s.FirstName).Not.Nullable();
            Map(s => s.LastName).Not.Nullable();
            Map(s => s.UserName).Not.Nullable();
            Map(s => s.PasswordHash).Not.Nullable();
            HasMany(s => s.LearningPaths);
            HasMany(s => s.Submissions);
            References(s => s.Organisation).Cascade.SaveUpdate();
        }
    }
}
