using System;
using System.Collections;
using System.Linq;

namespace LINQapi.Helpers
{
    public static class ListHelper
    {
        public static IList ToList(this IQueryable query)
        {
            var genericToList = typeof(Enumerable).GetMethod("ToList")
                .MakeGenericMethod(new Type[] { query.ElementType });
            return (IList)genericToList.Invoke(null, new[] { query });
        }

        public static bool Any(this IQueryable query)
        {
            var methods = typeof(Queryable).GetMethods();
            var method = methods.FirstOrDefault(m => m.Name.Equals("Any"));
            var gen = method.MakeGenericMethod(new Type[] { query.ElementType });
            return (bool)gen.Invoke(null, new[] { query });
        }
    }
}