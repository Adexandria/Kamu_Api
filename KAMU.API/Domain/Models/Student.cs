namespace KAMU.API.Domain.Models
{
    public class Student : Person
    {
        public IList<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
