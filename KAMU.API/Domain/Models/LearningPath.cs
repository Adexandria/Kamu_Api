namespace KAMU.API.Domain.Models
{
    public class LearningPath : BaseEntity
    {
        public virtual IList<SuperAdmin> SuperAdmins { get; set; } = new List<SuperAdmin>();
        public virtual IList<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual IList<Student> Students { get; set; } = new List<Student>();
    }
}
