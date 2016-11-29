using LINQapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LINQapi.Controllers
{
    public class ChartController : ApiController
    {
        [EnableCors(origins: "http://localhost:63342", headers: "*", methods: "*")]
        [HttpPost]
        public ChartResponseModel Post([FromBody] string fromWeb)
        {
            return new ChartResponseModel();
        }
    }
}
