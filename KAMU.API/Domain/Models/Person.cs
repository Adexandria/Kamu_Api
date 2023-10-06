namespace KAMU.API.Domain.Models
{
    public class Person : UserIdentity
    {
        public Organisation Organisation { get; set; }
        public IList<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();
    }
}
