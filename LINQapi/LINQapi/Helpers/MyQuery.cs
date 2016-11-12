using System.Linq;
namespace LINQapi.Helpers
{
    public class MyQuery
    {
        public IQueryable<object> result(MyDbSet db)
        {
            IQueryable<object>[] expressionsSet = new IQueryable<object>[10];
            for (int i = 0; i < 10; i++)
            {
                var temp = db.Customers.Take();
            }
            return " + originalQueryFromWeb + "; "
        }
    }
}