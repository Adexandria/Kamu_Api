using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    /// <summary>
    /// Maps the properties of a student object to the columns of a database table
    /// </summary>
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
           // HasMany(s => s.Submissions);
            References(s => s.Organisation);
        }
    }
}
