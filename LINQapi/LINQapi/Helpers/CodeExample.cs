using System.Linq;
using System.Linq.Expressions;
using static LINQapi.AdventureWorksLT2012Entities;

namespace LINQapi.Helpers
{
    public class CodeExample
    {
        private LINQapi.AdventureWorksLT2012Entities db = new LINQapi.AdventureWorksLT2012Entities();
        public Expression Execute()
        {
            return db.Customers.Where(cus=>cus.FirstName == "Alan").Take(2).Expression;
        }
    }
}