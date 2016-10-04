using System.CodeDom.Compiler;
using System.Collections.Generic;
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
        public List<string> errors = new List<string>();

        public QueryAnalyzer(string queryFromWeb, MyDbSet db)
        {
            this.db = db;
            originalQueryFromWeb = queryFromWeb;
            initialCount = db.ColectionSizes[originalQueryFromWeb.Split('.')[1]];
            generatedQuery = GenerateQueryFromString();
            if (errors.Count == 0)
            {
                Expression = generatedQuery.Expression;
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var list = generatedQuery.ToList();
                stopwatch.Stop();
                finalCount = list.Count;
                //executionTime = stopwatch.ElapsedMilliseconds;
                executionTime = stopwatch.ElapsedTicks;
            }
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
                foreach (CompilerError error in (CompilerErrorCollection)classRef)
                {
                    errors.Add(error.ErrorText);
                }
                return null;
            }
            IQueryable<object> targetValues = classRef.result(db);
            return targetValues;
        }
    }
}