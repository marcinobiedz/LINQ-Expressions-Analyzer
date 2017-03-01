using LINQapi.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Views
{
    [DataContract]
    public class TreeResponse
    {
        public TreeResponse()
        {
            isResponseValid = false;
            errors = new List<string>();
        }

        [DataMember(IsRequired = true)]
        public bool isResponseValid { get; set; }

        [DataMember]
        public List<string> errors { get; set; }

        [DataMember]
        public List<ExpressionTreeNode> tree { get; set; }
    }
}