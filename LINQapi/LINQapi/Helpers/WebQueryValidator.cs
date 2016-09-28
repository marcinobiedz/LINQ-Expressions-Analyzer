using System.Linq;

namespace LINQapi.Helpers
{
    public class WebQueryValidator
    {
        public bool isValid { get; private set; }
        private MyDbSet db;
        public WebQueryValidator(string queryFromWeb, MyDbSet db)
        {
            this.db = db;
            isValid = validateQuery(queryFromWeb);
        }
        private bool validateQuery(string query)
        {
            string[] queryParts = query.Split('.');
            if (queryParts.Length <= 0) return false;
            queryParts[0] = "db";
            if (!(db.ColectionSizes.Keys.Contains(queryParts[1]))) return false;
            return true;
        }
    }
}