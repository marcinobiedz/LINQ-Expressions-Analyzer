using LINQapi.Helpers;
using System;
using System.Linq;

namespace LINQapi.Tests
{
    internal class TestPlayground
    {
        public TestPlayground()
        {
            MyDbSet db = new MyDbSet();
            var a = db.SalesOrderDetails.Where(sod => sod.Product.ProductNumber.StartsWith("aaa")).Select(ob=>ob.UnitPrice);
            //IQueryable[] aa = new IQueryable[5];
            //MyDbSet db = new MyDbSet();
            //var a = db.SalesOrderDetails.AsQueryable().Join(db.SalesOrderHeaders,
            //    sod => sod.SalesOrderID,
            //    soh => soh.SalesOrderID,
            //    (sod, soh) => new { ID = sod.SalesOrderDetailID, An = soh.AccountNumber })
            //    .Where(obj => obj.An.StartsWith("10-4020-0002"))
            //    .Select(sel => sel.ID);
            //aa[0] = a;
            //Console.Write("a");
        }
    }
}