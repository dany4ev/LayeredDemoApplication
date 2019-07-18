using Autofac;
using Autofac.Integration.WebApi;
using Layered.Extensions.Attributes;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Layered.AspnetWebApi.Core.Infrastructure
{
    public class AutofacDependencyBuilder
    {
        public static void DependencyBuilder()
        {
            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.GetCustomAttribute<Injectable>() != null)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            //Build the Container
            var container = builder.Build();

            //Create the Dependency Resolver
            var resolver = new AutofacWebApiDependencyResolver(container);

            //Configuring WebApi with Dependency Resolver
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}