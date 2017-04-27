using System.Web.Http;

using Newtonsoft.Json.Serialization;

using Notify.Solution.WebApi.Filter;

namespace Notify.Solution.WebApi
{
    /// <summary>
    /// The web api config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            SetSerializationXmlFormat(config);
            SetSerializationJsonFormat(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        /// <summary>
        /// The set serialization json format.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void SetSerializationJsonFormat(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;

            // 解决json序列化时的循环引用问题
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            ////var JsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            ////设置key为驼峰命名规则 
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            ////Indented（缩进）
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            ////(时间格式只支持2种)json.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            ////时间格式("自定义格式")
            ////json.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            ////移除json序列化器
            ////config.Formatters.Remove(config.Formatters.JsonFormatter);
        }

        /// <summary>
        /// The set serialization xml format.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void SetSerializationXmlFormat(HttpConfiguration config)
        {
            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            ////Indenting（缩进）
            xml.Indent = true;
            ////移除xml序列化器
            ////onfig.Formatters.Remove(config.Formatters.XmlFormatter);
            ////xml.UseXmlSerializer = true;
        }
    }
}
