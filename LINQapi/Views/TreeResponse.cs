using LINQapi.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Views
{
    [DataContract]
    public class TreeResponse : BaseResponse
    {
        [DataMember]
        public List<ExpressionTreeNode> tree { get; set; }
    }
}