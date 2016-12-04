using LINQapi.Helpers;
using LINQapi.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LINQapi.Controllers
{
    public class ChartController : ApiController
    {
        private MyDbSet db = new MyDbSet();

        [EnableCors(origins: "http://localhost:63342", headers: "*", methods: "*")]
        [HttpPost]
        public ChartResponseModel Post([FromBody] string fromWeb)
        {
            //===============================================
            fromWeb = Constants.FROM_WEB;
            //============================================
            ChartResponseModel response = new ChartResponseModel();
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
