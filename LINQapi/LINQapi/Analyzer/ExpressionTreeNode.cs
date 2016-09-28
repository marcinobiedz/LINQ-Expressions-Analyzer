using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQapi.Analyzer
{
    public class ExpressionTreeNode
    {
        public ExpressionTreeNode(string text, int? parentId = null)
        {
            Text = text;
            ParentId = parentId;
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Text { get; set; }
        public string ExpressionString { get; set; }
    }
}