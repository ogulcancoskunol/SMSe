using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using SMSe.BLL.Service;
using SMSe.BLL.Service.Interface;
using SMSe.DAL.Repository;
using SMSe.DAL.Repository.Interface;

namespace SMSe.BLL.Config
{
    public static class AutofacConfig
    {
        public static void Configure(Assembly assembly)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(assembly);

            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
