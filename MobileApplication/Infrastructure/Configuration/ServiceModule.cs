
using AutoMapper;
using MobileApplication.Infrastructure.Repository.Implementations;
using MobileApplication.Infrastructure.Repository.Interfaces;
using MobileApplication.Manager.Services.Implementations;
using MobileApplication.Manager.Services.Interfaces;
using Services.Managers.Implementations;
using Services.Managers.Interfaces;


namespace MobileApplication.Infrastructure.Configuration
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IMobileInfoRepository, MobileInfoRepository>();
            services.AddScoped<IMobileInfoService, MobileInfoService>();
            services.AddTransient<IMobileSpecsRepository, MobileSpecsRepository>();
            services.AddTransient<IMobileSpecsService, MobileSpecsService>();
            services.AddScoped<ITokenService, TokenService>();

            // Auto Mapper Configurations
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfiler());
            //});
            // IMapper mapper = mapperConfig.CreateMapper();
            // services.AddSingleton(mapper);

        } 
    }
}
