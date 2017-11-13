using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Bryan.Architecture.Web
{
    /// <summary>The web api application.</summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>The application_ start.</summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}