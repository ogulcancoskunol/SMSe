using AutoMapper;
using SMSe.BLL.ModelViews;
using SMSe.DAL;

namespace SMSe.BLL.Config
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
