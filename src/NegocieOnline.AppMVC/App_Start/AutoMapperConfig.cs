using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using NegocieOnline.AppMVC.ViewModels;
using NegocieOnline.Business.Models.Cep;

namespace NegocieOnline.AppMVC
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetCallingAssembly().GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cep, CepViewModel>().ReverseMap();
        }
    }
}