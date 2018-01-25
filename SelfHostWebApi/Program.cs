using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHostWebApi
{
    /*
     * nuget 收索 Microsoft.AspNet.WebApi.Client 安装
     * 包含dll
     * <package id="Microsoft.AspNet.WebApi.Client" version="5.2.3" targetFramework="net461" />
     * <package id="Microsoft.AspNet.WebApi.Core" version="5.2.3" targetFramework="net461" />
     * <package id="Microsoft.AspNet.WebApi.SelfHost" version="5.2.3" targetFramework="net461" />
     * <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net461" />
     * 安装完后会多这么几个dll
     * System.Web.Http.dll
     * System.Net.Http.dll
     * System.Net.Http.Formatting.dll
     * System.Web.Http.SelfHost.dll
    */

    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">args</param>
        internal static void Main(string[] args)
        {
            Assembly.Load("WebApi2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");    //加载外部程序集
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("SelfHost启动成功");
                Console.ReadLine();
            }
        }
    }
}