using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace Bryan.Architecture.Service.App_Start
{
    /// <summary>The autofac config.</summary>
    public class AutofacConfig
    {
        /// <summary>The register.</summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            var dalAssembly = Assembly.Load("Bryan.Architecture.DataAccess");
            var bllAssembly = Assembly.Load("Bryan.Architecture.BusinessLogic");

            var repositoryType = dalAssembly.GetTypes().FirstOrDefault(item => item.Name.Contains("BaseRepository"));
            var dbcontextType = dalAssembly.GetTypes().FirstOrDefault(item => item.Name == "BryanArchitecutureEntities");

            builder.RegisterType(dbcontextType)
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterGeneric(repositoryType)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(bllAssembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}