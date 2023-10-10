namespace KAMU.API.Domain.Models
{
    public class BaseEntity : IEntity
    {
        public virtual Guid Id { get; set; }
    }
}
