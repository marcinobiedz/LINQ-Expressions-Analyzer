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
        private ExpressionTreeVizualizer expTreeVizualizer = new ExpressionTreeVizualizer();

        [EnableCors(origins: "http://localhost:63342", headers: "*", methods: "*")]
        [HttpPost]
        public TreeResponseModel Post([FromBody] string fromWeb)
        {
            //===============================================
            //fromWeb = Constants.FROM_WEB_REF;
            //============================================
            TreeResponseModel response = new TreeResponseModel();
            if (string.IsNullOrEmpty(fromWeb) || string.IsNullOrWhiteSpace(fromWeb))
            {
                response.isResponseValid = false;
                response.errors.Add("You did not typed any LINQ expression :(");
                return response;
            }
            WebQueryValidator queryValidator = new WebQueryValidator(fromWeb, Constants.db);
            if (queryValidator.isValid)
            {
                fromWeb = queryValidator.appendQuery(fromWeb);
                QueryAnalyzer queryAna = new QueryAnalyzer(fromWeb, Constants.db);
                if (queryAna.errors.Count > 0)
                {
                    response.isResponseValid = false;
                    response.errors = queryAna.errors;
                }
                else
                {
                    queryAna.AnalyzeTree();
                    expTreeVizualizer.GetExpressionTreeNode(queryAna.Expression);
                    response.tree = expTreeVizualizer.nodes;
                    response.tree.Sort(new ExpressionTreeNodeComparer());
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
