using System;
using System.Web.Http;

using Notify.Solution.WebApi.Models;

namespace Notify.Solution.WebApi.Controllers
{
    /// <summary>
    /// The json controller.
    /// </summary>
    public class JsonController : ApiController
    {
        /// <summary>
        /// The json.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonModel"/>.
        /// </returns>
        [HttpGet]
        public JsonModel Json()
        {
            return new JsonModel { DateTime = DateTime.Now, Message = "sssdsds" };
        }
    }
}
