using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Models
{
    [DataContract]
    public class TableInfoModel
    {
        public TableInfoModel(string TableName, int TableCount)
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