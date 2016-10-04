using LINQapi.Analyzer;
using LINQapi.Helpers;
using LINQapi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace LINQapi.Controllers
{
    public class ExpTreeController : ApiController
    {
        private MyDbSet db = new MyDbSet();
        private ExpressionTreeVizualizer expTreeVizualizer = new ExpressionTreeVizualizer();

        public TreeResponseModel Get([FromBody] string expression)
        {
            //===============================================
            string fromWeb = "db.Customers.AsQQQueryable().Where(cus => cus.CustomerID > 5 && cus.FirstName.StartsWith(\"Kat\")).Take(5).Select(cus => new { cus.EmailAddress })";
            //============================================

            TreeResponseModel response = new TreeResponseModel();
            WebQueryValidator queryValidator = new WebQueryValidator(fromWeb, db);
            if (queryValidator.isValid)
            {
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
                    response.initialCount = queryAna.initialCount;
                    response.finalCount = queryAna.finalCount;
                    response.executionTime = queryAna.executionTime;
                    response.stringExpression = queryAna.Expression.ToString();
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
