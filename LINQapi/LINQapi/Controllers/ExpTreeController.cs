using LINQapi.Analyzer;
using LINQapi.Helpers;
using System.Collections.Generic;
using System.Web.Http;

namespace LINQapi.Controllers
{
    public class ExpTreeController : ApiController
    {
        private MyDbSet db = new MyDbSet();
        private ExpressionTreeVizualizer expTreeVizualizer = new ExpressionTreeVizualizer();

        public List<ExpressionTreeNode> Get([FromBody] string expression)
        {
            List<ExpressionTreeNode> tree = new List<ExpressionTreeNode>();
            string fromWeb = "db.Customers.AsQueryable().Where(cus => cus.CustomerID > 5 && cus.FirstName.StartsWith(\"Kat\")).Take(5).Select(cus => new { cus.EmailAddress })";
            //============================================
            var queryValidator = new WebQueryValidator(fromWeb, db);
            if (queryValidator.isValid)
            {
                var queryAna = new QueryAnalyzer(fromWeb, db);
                expTreeVizualizer.GetExpressionTreeNode(queryAna.Expression);
                tree = expTreeVizualizer.nodes;
                tree.Sort(new ExpressionTreeNodeComparer());
            }
            else
            {

            }
            return tree;
        }
    }
}
