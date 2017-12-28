using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.WebApi;

using Bryan.Architecture.AOP.Interceptor;
using Bryan.Architecture.Utility.Cache.Implement;
using Bryan.Architecture.Utility.Cache.Interface;

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
                .EnableInterfaceInterceptors()
                .InstancePerRequest();

            var redisHost = ConfigurationManager.AppSettings["RedisHost"];
            var redisPassword = ConfigurationManager.AppSettings["RedisPassword"];

            var parameters = new List<Parameter>
                                 {
                                     new NamedParameter("dataBaseNumber", 0),
                                     new NamedParameter("host", redisHost),
                                     new NamedParameter("port", 6379),
                                     new NamedParameter("password", redisPassword)
                                 };
            builder.RegisterType<RedisCache>().As<ICache>().WithParameters(parameters).InstancePerRequest();
            builder.Register(c => new Interceptor(new RedisCache(0, redisHost, "6379", redisPassword))).SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}