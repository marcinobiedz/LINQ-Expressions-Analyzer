using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQapi.Helpers
{
    public class Constants
    {
        public static readonly int DB_DIVIDER = 10;
        public static readonly string FROM_WEB = "db.SalesOrderDetails.Join(db.SalesOrderHeaders," +
            "sod => sod.SalesOrderID," +
            "soh => soh.SalesOrderID," +
            "(sod, soh) => new { ID = sod.SalesOrderDetailID, An = soh.AccountNumber })" +
            ".Where(obj => obj.An.StartsWith(\"10-4020-0002\"))" +
            ".Select(sel => sel.ID)";
    }
}