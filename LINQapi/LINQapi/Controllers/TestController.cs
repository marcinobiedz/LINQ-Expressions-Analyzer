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
        public void get(int id)
        {
            Console.Write(id);
        }
    }
}
