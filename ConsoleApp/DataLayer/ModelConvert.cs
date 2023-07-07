using AutoMapper;
using System.Reflection;

namespace DataLayer
{
    public static class ModelConvert<T1, T2>
    {
        /// <summary>
        /// this method maps the data from T1 to T2.
        /// </summary>
        /// <param name="userobj"></param>
        /// <returns></returns>
        public static T2 Converter(T1 userobj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = config.CreateMapper();
            return mapper.Map<T2>(userobj);

            //T2 requiredModel = new T2();
            //PropertyInfo[] sourceProperties = typeof(T1).GetProperties();
            //PropertyInfo[] destinationProperties = typeof(T2).GetProperties();
            //foreach (var property in sourceProperties)
            //{
            //    var destinationProperty = destinationProperties.FirstOrDefault(destProperty => destProperty.Name == property.Name && destProperty.PropertyType == property.PropertyType);
            //    if (destinationProperty != null)
            //    {
            //        var value = property.GetValue(userobj);
            //        destinationProperty.SetValue(requiredModel, value);
            //    }
            //}
            //return requiredModel;
        }
    }
}
