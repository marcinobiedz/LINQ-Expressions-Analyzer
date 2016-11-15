using LINQapi.Analyzer;
using LINQapi.Helpers;
using LINQapi.Models;
using LINQapi.Tests;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LINQapi.Controllers
{
    public class ExpTreeController : ApiController
    {
        private MyDbSet db = new MyDbSet();
        private ExpressionTreeVizualizer expTreeVizualizer = new ExpressionTreeVizualizer();

        [EnableCors(origins: "http://localhost:63342", headers: "*", methods: "*")]
        [HttpPost]
        public TreeResponseModel Post([FromBody] string fromWeb)
        {
            //===============================================
            //string fromWeb = "db.Customers.AsQueryable().Where(cus => cus.CustomerID > 5 && cus.FirstName.StartsWith(\"Kat\")).Take(5).Select(cus => new { cus.EmailAddress })";
            //============================================
            TestPlayground tp = new TestPlayground();

            TreeResponseModel response = new TreeResponseModel();
            if (string.IsNullOrEmpty(fromWeb) || string.IsNullOrWhiteSpace(fromWeb))
            {
                response.isResponseValid = false;
                response.errors.Add("You did not typed any LINQ expression :(");
                return response;
            }
            WebQueryValidator queryValidator = new WebQueryValidator(fromWeb, db);
            if (queryValidator.isValid)
            {
                fromWeb = queryValidator.appendQuery(fromWeb);
                QueryAnalyzer queryAna = new QueryAnalyzer(fromWeb, db);
                if (queryAna.errors.Count > 0)
                {
                    response.isResponseValid = false;
                    response.errors = queryAna.errors;
                }
                else
                {
                    expTreeVizualizer.GetExpressionTreeNode(queryAna.Expression);
                    response.tree = expTreeVizualizer.nodes;
                    response.tree.Sort(new ExpressionTreeNodeComparer());
                    response.initialCounts = queryAna.initialCounts;
                    response.finalCounts = queryAna.finalCounts;
                    response.executionTimes = queryAna.executionTimes;
                    response.isResponseValid = true;
                }
            }
            else
            {
                response.isResponseValid = queryValidator.isValid;
                response.errors.Add("There is no such table in the database! :(");
            }
            return response;
        }
    }
}
