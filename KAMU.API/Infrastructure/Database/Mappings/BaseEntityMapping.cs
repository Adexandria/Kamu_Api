using FluentNHibernate.Mapping;
using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    public class BaseEntityMapping<T> : ClassMap<T> where T : IEntity
    {
        public BaseEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
        }
    }
}
