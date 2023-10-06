namespace KAMU.API.Domain.Models
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
