using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// Converts an object to another object
    /// </summary>
    public static class ConverterExtension
    {
        /// <summary>
        /// Converts an object to another object
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="entity">The source object</param>
        /// <returns>Destination object</returns>
        public static T ConvertTo<T>(this IEntity entity) where T: IEntity
        {
           T obj = (T)Activator.CreateInstance(typeof(T));

           var properties =  obj.GetType().GetProperties();
           var personProperties = entity.GetType().GetProperties();
           for(int i = 0; i < properties.Length; i++)
           {
                var property = personProperties.Where(s => s.Name == properties[i].Name).FirstOrDefault();
                if (property == null)
                    continue;

                var value = property.GetValue(entity, null);
                properties[i].SetValue(obj,value);
           }
           return obj;
        }
    }
}
