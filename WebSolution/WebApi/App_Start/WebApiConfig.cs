using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Configuration;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 跨域配置
            //1. 只需要在这里添加该项即可
            //config.EnableCors(new EnableCorsAttribute("*","*","*"));

            //2. 添加配置项
            // 2.1在webconfig中添加配置项
            // 2.2 在register中添加cors配置
            #region register 配置
            var allowedMethods = ConfigurationManager.AppSettings["cors:allowedMethods"].ToString();
            var allowedOrigin = ConfigurationManager.AppSettings["cors:allowedOrigin"].ToString();
            var allowedHeaders = ConfigurationManager.AppSettings["cors:allowedHeaders"].ToString();
            var geduCors = new EnableCorsAttribute(allowedOrigin,allowedMethods, allowedHeaders)
            {
                SupportsCredentials = true
            };
            config.EnableCors(geduCors);
            #endregion 
            //3. 利用特性配置在某一个controller 或action上面。
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
