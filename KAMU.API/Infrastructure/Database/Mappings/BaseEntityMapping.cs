using FluentNHibernate.Mapping;
using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Database.Mappings
{
    /// <summary>
    /// Generates and Maps the Id of entities to id column of the database
    /// </summary>
    /// <typeparam name="T">a type implementing IEntity</typeparam>
    public class BaseEntityMapping<T> : ClassMap<T> where T : IEntity
    {
        public BaseEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
        }
    }
}
