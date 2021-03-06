﻿using System.Web.Http;

using Notify.Solution.WebApi.Business;
using Notify.Solution.WebApi.Filter;
using Notify.Solution.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;

namespace Notify.Solution.WebApi.Controllers
{
    /// <summary>
    /// ProductController
    /// </summary>
    [WbeApiFilter]
    public class ProductController : ApiController
    {
        /// <summary>
        /// The test.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        [HttpGet]
        [HttpPost]
        public XmlModel Test(HttpRequestMessage req)
        {
            var content = req.Content.ReadAsStringAsync().Result;


            object o = "我是测试业务对象";

            // 异步执行业务
            Logic.Intance.Exec(o);
            return new XmlModel
                       {
                           DateTime = DateTime.Now,
                           IsSucceed = true,
                           Message = "OK"
                       };
        }

        /// <summary>
        /// The pay order.
        /// </summary>
        /// <param name="orderNumber">
        /// The order number.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <returns>
        /// The <see cref="Result"/>.
        /// </returns>
        [HttpGet]
        [HttpPost]
        public Result PayOrder(string orderNumber, decimal amount)
        {
            return null;
        }
    }


    public class Par
    {
        public string Partner { get; set; }

        public string Timestamp { get; set; }

        public string Sign { get; set; }
    }
}
