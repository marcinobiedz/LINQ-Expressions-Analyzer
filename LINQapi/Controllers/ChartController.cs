using LINQapi.Helpers;
using LINQapi.Views;
using System.Web.Http;

namespace LINQapi.Controllers
{
    public class ChartController : ApiController
    {
        [HttpPost]
        public ChartResponse Post([FromBody] string fromWeb)
        {
            //===============================================
            //fromWeb = Constants.FROM_WEB_REF;
            //============================================
            ChartResponse response = new ChartResponse();
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
                    queryAna.AnalyzeChart();
                    response.initialCounts = queryAna.initialCounts;
                    response.finalCounts = queryAna.finalCounts;
                    response.executionTimes = queryAna.executionTimes;
                    response.tablesInfo = queryAna.tablesInfo;
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
