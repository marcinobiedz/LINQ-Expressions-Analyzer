using LINQapi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LINQapi.Controllers
{
    public class TestController : ApiController
    {
        public void Get(int id)
        {
            var a = "db.Customers.Where(cus=>cus.FirstName == \"Alan\").Take(2)";
            var test = new ExpressionGenerator();
            //var a1 = test.Execute(a);
            test.Execute(a);
        }
    }
}
