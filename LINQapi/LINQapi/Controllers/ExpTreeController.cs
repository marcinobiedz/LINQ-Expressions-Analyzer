using LINQapi.Helpers;
using System.Web.Http;

namespace LINQapi.Controllers
{
    public class ExpTreeController : ApiController
    {
        private MyDbSet db = new MyDbSet();
        private ExpressionTreeAnalyzer expTreeAnalyzer = new ExpressionTreeAnalyzer();

        public void Get([FromBody] string expression)
        {
            string fromWeb = "db.Customers.AsQueryable().Where(cus => cus.CustomerID > 5 && cus.FirstName.StartsWith(\"Kat\")).Take(5).Select(cus => new { cus.EmailAddress })";
            //============================================
            var queryValidator = new WebQueryValidator(fromWeb, db);
            if (queryValidator.isValid)
            {
                var queryGen = new QueryGenerator(fromWeb, db);
                var rootNode = expTreeAnalyzer.GetExpressionTreeNode(queryGen.Expression);
            }
            else
            {

            }
        }
    }
}
