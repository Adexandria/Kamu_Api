using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    public class LearningPathMapping : BaseEntityMapping<LearningPath>
    {
        public LearningPathMapping()
        {
            Table("LearningPaths");
            HasManyToMany(s => s.Instructors).
                Table("LearningPathToInstructor")
                .ParentKeyColumn("LearningPath_id")
                .ChildKeyColumn("Instructor_id");
            HasManyToMany(s=>s.SuperAdmins)
                .Table("LearningPathToSuperAdmin")
                 .ParentKeyColumn("LearningPath_id")
                .ChildKeyColumn("SuperAdmin_id");
            HasManyToMany(s=>s.Students)
                .Table("LearningPathToStudent")
                 .ParentKeyColumn("LearningPath_id")
                .ChildKeyColumn("Student_id");
        }
    }
}
