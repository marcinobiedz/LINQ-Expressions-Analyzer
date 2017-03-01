using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Views
{
    [DataContract]
    public class TableResponse
    {
        public TableResponse(string TableName, int TableCount)
        {
            this.TableName = TableName;
            this.TableCount = TableCount;
        }

        [DataMember]
        public string TableName { get; set; }

        [DataMember]
        public int TableCount { get; set; }
    }
}