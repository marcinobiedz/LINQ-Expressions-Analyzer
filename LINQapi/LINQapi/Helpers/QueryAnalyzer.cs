using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LINQapi.Helpers
{
    public class QueryAnalyzer
    {
        private string originalQueryFromWeb;
        private MyDbSet db;
        private StringBuilder sb = new StringBuilder();
        private ClassGenerator classGen = new ClassGenerator();
        private IQueryable<object> generatedQuery;
        public Expression Expression { get; }
        public int initialCount { get; }
        public int finalCount { get; }
        public long executionTime { get; }

        public QueryAnalyzer(string queryFromWeb, MyDbSet db)
        {
            this.db = db;
            originalQueryFromWeb = queryFromWeb;
            generatedQuery = GenerateQueryFromString();
            Expression = generatedQuery.Expression;
            initialCount = db.ColectionSizes[originalQueryFromWeb.Split('.')[1]];

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = generatedQuery.ToList();
            stopwatch.Stop();
            finalCount = list.Count;
            executionTime = stopwatch.ElapsedMilliseconds;
        }

        private IQueryable<object> GenerateQueryFromString()
        {
            // Create the class as usual
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("namespace LINQapi.Helpers");
            sb.AppendLine("{");
            sb.AppendLine("      public class MyQuery");
            sb.AppendLine("      {");
            sb.AppendLine("            public IQueryable<object> result(MyDbSet db)");
            sb.AppendLine("            {");
            sb.AppendLine("                 return " + originalQueryFromWeb + ";");
            sb.AppendLine("            }");
            sb.AppendLine("      }");
            sb.AppendLine("}");
            // The finished code

            string classCode = sb.ToString();
            dynamic classRef;
            // Pass the class code, the namespace of the class and the list of extra assemblies needed
            classRef = classGen.generateClass(classCode, "LINQapi.Helpers.MyQuery");

            // If the compilation process returned an error, then show to the user all errors
            if (classRef is CompilerErrorCollection)
            {
                StringBuilder sberror = new StringBuilder();
                foreach (CompilerError error in (CompilerErrorCollection)classRef)
                {
                    sberror.AppendLine(string.Format("{0}:{1} {2} {3}",
                                       error.Line, error.Column, error.ErrorNumber, error.ErrorText));
                }
                return null;
            }
            IQueryable<object> targetValues = classRef.result(this.db);
            return targetValues;
        }
    }
}