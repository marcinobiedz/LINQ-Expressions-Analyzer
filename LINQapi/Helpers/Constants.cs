using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LINQapi.Helpers
{
    public class Constants
    {
        public static MyDbSet db;
        public static readonly int DB_DIVIDER = int.Parse(ConfigurationManager.AppSettings["DB_DIVIDER"]);
        public static readonly string FROM_WEB_REF = ConfigurationManager.AppSettings["FROM_WEB_REF"];
    }
}