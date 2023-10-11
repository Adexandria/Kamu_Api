namespace KAMU.API.Domain.Models
{
    public class Submission : BaseEntity
    {
        public virtual Student Student { get; set; }
    }
}
