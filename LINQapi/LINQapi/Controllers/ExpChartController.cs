using LINQapi.Analyzer;
using LINQapi.Helpers;
using LINQapi.Models;
using LINQapi.Tests;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LINQapi.Controllers
{
    public class ExpChartController : ApiController
    {
        private MyDbSet db = new MyDbSet();

        [EnableCors(origins: "http://localhost:63342", headers: "*", methods: "*")]
        [HttpPost]
        public ChartResponseModel Post([FromBody] string fromWeb)
        {
            //===============================================
            fromWeb = "db.SalesOrderDetails.Join(db.SalesOrderHeaders," +
            "sod => sod.SalesOrderID," +
            "soh => soh.SalesOrderID," +
            "(sod, soh) => new { ID = sod.SalesOrderDetailID, An = soh.AccountNumber })" +
            ".Where(obj => obj.An.StartsWith(\"10-4020-0002\"))" +
            ".Select(sel => sel.ID)";
            //============================================
            TestPlayground tp = new TestPlayground();

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
