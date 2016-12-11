using LINQapi.Analyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LINQapi.Helpers
{
    public class ExpressionTreeVizualizer
    {
        private Func<int> nextId;
        private Func<int> createIterator()
        {
            int nextIndex = 0;
            return () =>
            {
                return nextIndex++;
            };
        }
        public List<ExpressionTreeNode> nodes = new List<ExpressionTreeNode>();

        public ExpressionTreeVizualizer()
        {
            nextId = createIterator();
        }
        public void GetExpressionTreeNode(Expression expression, string prefix = null, int? parentId = null)
        {
            ExpressionTreeNode node = null;
            if (expression is BinaryExpression)
            {
                var expr = expression as BinaryExpression;
                node = new ExpressionTreeNode(string.Format("BinaryExpression: [{0}]", expr.NodeType), parentId);
                node.Id = nextId();
                GetExpressionTreeNode(expr.Left, "Left", parentId: node.Id);
                GetExpressionTreeNode(expr.Right, "Right", parentId: node.Id);
            }
            if (expression is BlockExpression)
            {
                var expr = expression as BlockExpression;
                node = new ExpressionTreeNode(string.Format("BlockExpression Expressions:"), parentId);
                node.Id = nextId();
                expr.Expressions.ToList().ForEach(a => GetExpressionTreeNode(a, parentId: node.Id));
            }
            if (expression is ConditionalExpression)
            {
                var expr = expression as ConditionalExpression;
                node = new ExpressionTreeNode(string.Format("ConditionalExpression: [{0}]", expr.NodeType), parentId);
                node.Id = nextId();
                GetExpressionTreeNode(expr.Test, "Test", parentId: node.Id);
                GetExpressionTreeNode(expr.IfTrue, "IfTrue", parentId: node.Id);
                GetExpressionTreeNode(expr.IfFalse, "IfFalse", parentId: node.Id);
            }
            if (expression is ConstantExpression)
            {
                var expr = expression as ConstantExpression;
                node = new ExpressionTreeNode(string.Format("ConstantExpression [{0}]: {1}", expr.Type.Name, expr.Value),
                    expr.Value.ToString(),
                    parentId);
                node.Id = nextId();
            }
            if (expression is DebugInfoExpression)
            {
                var expr = expression as DebugInfoExpression;
            }
            if (expression is DefaultExpression)
            {
                var expr = expression as DefaultExpression;
                node = new ExpressionTreeNode(string.Format("DefaultExpression: [{0}]", expr.Type.Name), parentId);
                node.Id = nextId();
            }
            if (expression is DynamicExpression)
            {
                var expr = expression as DynamicExpression;
                node = new ExpressionTreeNode(string.Format("DynamicExpression [{0}] Arguments:", expr.DelegateType.Name), parentId);
                node.Id = nextId();
                expr.Arguments.ToList().ForEach(a => GetExpressionTreeNode(a, parentId: node.Id));
            }
            if (expression is GotoExpression)
            {
                var expr = expression as GotoExpression;
            }
            if (expression is IndexExpression)
            {
                var expr = expression as IndexExpression;
                node = new ExpressionTreeNode(string.Format("IndexExpression [{0}] Arguments:", expr.Indexer.Name), parentId);
                node.Id = nextId();
                expr.Arguments.ToList().ForEach(a => GetExpressionTreeNode(a, parentId: node.Id));
            }
            if (expression is InvocationExpression)
            {
                var expr = expression as InvocationExpression;
                node = new ExpressionTreeNode(string.Format("InvocationExpression [{0}] Arguments:", expr.Expression), parentId);
                node.Id = nextId();
                expr.Arguments.ToList().ForEach(a => GetExpressionTreeNode(a, parentId: node.Id));
                GetExpressionTreeNode(expr.Expression, "Expression", node.Id);
            }
            if (expression is LabelExpression)
            {
                var expr = expression as LabelExpression;
            }
            if (expression is LambdaExpression)
            {
                //Extended node
                var expr = expression as LambdaExpression;
                string parameters = "", nodeText = "";
                for (var i = 0; i < expr.Parameters.Count; i++)
                {
                    parameters = string.Join(", ", expr.Parameters.Select(p => p.Name + ": " + p.Type.Name).ToArray());
                    nodeText = string.Join(", ", expr.Parameters.Select(p => p.Name).ToArray());
                }
                node = new ExpressionTreeNode(string.Format("Lambda [{0}], Params: [{1}]:", expr.ReturnType, parameters),
                    nodeText + " =>",
                    parentId);
                node.Id = nextId();
                GetExpressionTreeNode(expr.Body, parentId: node.Id);
            }
            if (expression is ListInitExpression)
            {
                var expr = expression as ListInitExpression;
            }
            if (expression is LoopExpression)
            {
                var expr = expression as LoopExpression;
            }
            if (expression is MemberExpression)
            {
                var expr = expression as MemberExpression;
                //node = new ExpressionTreeNode(string.Format("MemberExpression [{0}]: {1}", expr.Type.Name, expr.Expression.ToString() + "." + 
                //expr.Member.Name), expr.Expression.ToString() + "." + expr.Member.Name, parentId);
                node = new ExpressionTreeNode(string.Format("MemberExpression [{0}]: {1}", expr.Type.Name, expr.Member.Name), expr.Member.Name, parentId);
                node.Id = nextId();
                // To comment with second version
                GetExpressionTreeNode(expr.Expression, parentId: node.Id);
            }
            if (expression is MemberInitExpression)
            {
                var expr = expression as MemberInitExpression;
                node = new ExpressionTreeNode(string.Format("MemberInitExpression [{0}]:", expr.NewExpression.Type), parentId);
                node.Id = nextId();
                expr.Bindings.ToList().ForEach(b => new ExpressionTreeNode(b.ToString(), node.Id));
            }
            if (expression is MethodCallExpression)
            {
                //Extended node
                var expr = expression as MethodCallExpression;
                node = new ExpressionTreeNode(string.Format("MethodCallExpression [{0}] Arguments:", expr.Method.Name),
                    expr.Method.Name,
                    parentId);
                node.Id = nextId();
                if (expr.Object != null)
                    GetExpressionTreeNode(expr.Object, parentId: node.Id);
                expr.Arguments.ToList().ForEach(a => GetExpressionTreeNode(a, parentId: node.Id));
            }
            if (expression is NewArrayExpression)
            {
                var expr = expression as NewArrayExpression;
            }
            if (expression is NewExpression)
            {
                var expr = expression as NewExpression;
                node = new ExpressionTreeNode(string.Format("NewExpression Arguments:"), parentId);
                node.Id = nextId();
                for (int i = 0; i < expr.Arguments.Count; i++)
                    GetExpressionTreeNode(expr.Arguments[i], expr.Members[i].Name, node.Id);
            }
            if (expression is ParameterExpression)
            {
                var expr = expression as ParameterExpression;
                node = new ExpressionTreeNode(string.Format("ParameterExpression [{0}]: {1}", expr.Type, expr.Name), expr.Name, parentId);
                node.Id = nextId();
            }
            if (expression is RuntimeVariablesExpression)
            {
                var expr = expression as RuntimeVariablesExpression;
            }
            if (expression is SwitchExpression)
            {
                var expr = expression as SwitchExpression;
            }
            if (expression is TryExpression)
            {
                var expr = expression as TryExpression;
            }
            if (expression is TypeBinaryExpression)
            {
                var expr = expression as TypeBinaryExpression;
                node = new ExpressionTreeNode(string.Format("TypeBinaryExpression [{0}] Operand:", expr.TypeOperand), parentId);
                node.Id = nextId();
                GetExpressionTreeNode(expr.Expression, parentId: node.Id);
            }
            if (expression is UnaryExpression)
            {
                var expr = expression as UnaryExpression;
                node = new ExpressionTreeNode(string.Format("UnaryExpression [{0}] Operand:", expr.NodeType), parentId);
                node.Id = nextId();
                GetExpressionTreeNode(expr.Operand, parentId: node.Id);
            }
            if (node == null)
            {
                node = new ExpressionTreeNode(string.Format("Unkown Node [{0}-{1}]: {2}", expression.GetType().Name, expression.NodeType, expression), parentId);
                node.Id = nextId();
            }
            if (prefix != null)
                node.Text = string.Format("{0} => {1}", prefix, node.Text);
            node.ExpressionString = expression.ToString();
            nodes.Add(node);
        }
    }
}