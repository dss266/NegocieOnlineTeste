using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using NegocieOnline.Business.Core.Notifications;
using NegocieOnline.Business.Models.Cep;
using NegocieOnline.Business.Models.Cep.Services;
using NegocieOnline.Infra.Data;
using NegocieOnline.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace NegocieOnline.AppMVC
{
    public class DenpendecyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();

            container.Options.DefaultLifestyle = new WebRequestLifestyle();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<NegocieOnlineDbContext> (Lifestyle.Scoped);
            container.Register<ICepRepository,CepRepository> (Lifestyle.Scoped);
            container.Register<ICepService,CepService>(Lifestyle.Scoped);
            container.Register<INotification,Notificador>(Lifestyle.Scoped);
            
            
            container.RegisterSingleton(()=> AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}