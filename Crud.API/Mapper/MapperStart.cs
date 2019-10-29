using AutoMapper;

namespace Crud.API
{
    class MapperStart
    {
        public static MapperConfiguration Start()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
                c.AddProfile<CrudProfile>());
            config.AssertConfigurationIsValid<CrudProfile>();

            return config;
        }
    }
}
