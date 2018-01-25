using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi2.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [HttpPost]
        public string Index()
        {
            return "OK";
        }
    }
}