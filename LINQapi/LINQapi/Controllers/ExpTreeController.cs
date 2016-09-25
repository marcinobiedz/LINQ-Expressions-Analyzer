using LINQapi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LINQapi.Controllers
{
    public class ExpTreeController : ApiController
    {
        private MyDbSet db = new MyDbSet();
        private ExpressionTreeAnalyzer expTreeAnalyzer;
        public void Get(int id)
        {
            var expGen = new ExpressionGenerator();
            var resultExpression = expGen.GenerateExpression("db.Customers.AsQueryable().Where(cus => cus.CustomerID > 5)", db);
            expTreeAnalyzer = new ExpressionTreeAnalyzer(resultExpression);
        }
    }
}
