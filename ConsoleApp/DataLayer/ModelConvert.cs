using AutoMapper;

namespace DataLayer
{
    public static class ModelConvert<T1, T2>
    {
        public static T2 Converter(T1 userobj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = config.CreateMapper();
            return mapper.Map<T2>(userobj);
        }
    }
}
