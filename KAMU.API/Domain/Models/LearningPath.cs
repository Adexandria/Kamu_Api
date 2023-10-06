namespace KAMU.API.Domain.Models
{
    public class LearningPath : BaseEntity
    {
        public IList<SuperAdmin> SuperAdmins { get; set; } = new List<SuperAdmin>();
        public IList<Instructor> Instructors { get; set; } = new List<Instructor>();
        public IList<Student> Students { get; set; } = new List<Student>();
    }
}
