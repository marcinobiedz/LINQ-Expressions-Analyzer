using System.Linq;
using ExpressionTreeViewer;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            var languages = new[] { "C#", "J#", "VB", "Delphi", "F#", "COBOL", "Python" };
            var queryable = languages.AsQueryable().Where(l => l.EndsWith("#") && l != "j#")
                .Take(3).Select(l => new { Name = l, IsSelected = true });
            System.Console.WriteLine(queryable.GetType().Name);
            var myQ = queryable.Expression;
            new VisualizerDevelopmentHost(queryable.Expression, typeof(ExpressionTreeVisualizer), typeof(ExpressionTreeObjectSource)).ShowVisualizer();
        }
    }
}
