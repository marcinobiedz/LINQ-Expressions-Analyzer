using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQapi.Analyzer
{
    public class ExpressionTreeNode
    {
        public ExpressionTreeNode(string text)
        {
            this.Text = text;
            this.Nodes = new List<ExpressionTreeNode>();
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
        public List<ExpressionTreeNode> Nodes { get; set; }
        public string ExpressionString { get; set; }
    }
}