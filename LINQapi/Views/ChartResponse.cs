using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Views
{
    [DataContract]
    public class ChartResponse : BaseResponse
    {
        [DataMember]
        public int[] initialCounts { get; set; }

        [DataMember]
        public int[] finalCounts { get; set; }

        [DataMember]
        public long[] executionTimes { get; set; }

        [DataMember]
        public TableResponse[] tablesInfo { get; set; }
    }
}