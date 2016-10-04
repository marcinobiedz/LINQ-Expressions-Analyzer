﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LINQapi.Analyzer
{
    [DataContract]
    public class ExpressionTreeNode
    {
        public ExpressionTreeNode(string text, int? parentId = null)
        {
            Text = text;
            ParentId = parentId;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? ParentId { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string ExpressionString { get; set; }
    }
}