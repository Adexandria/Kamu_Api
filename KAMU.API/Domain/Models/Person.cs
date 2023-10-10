namespace KAMU.API.Domain.Models
{
    public class Person : UserIdentity
    {
        public Person()
        {
            LearningPaths = new List<LearningPath>();
        }
        public virtual Organisation Organisation { get; set; }
        public virtual IList<LearningPath> LearningPaths { get; set; }
    }
}
