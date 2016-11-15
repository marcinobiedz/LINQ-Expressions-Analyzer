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
        private IQueryable[] generatedQueries;
        public Expression Expression { get; }
        public int[] initialCounts { get; }
        public int[] finalCounts { get; }
        public long[] executionTimes { get; }
        public List<string> errors = new List<string>();

        public QueryAnalyzer(string queryFromWeb, MyDbSet db)
        {
            this.db = db;
            originalQueryFromWeb = queryFromWeb;
            generatedQueries = GenerateQueryFromString();
            if (errors.Count == 0)
            {
                Expression = generatedQueries[0].Expression;
                initialCounts = new int[Constants.DB_DIVIDER];
                executionTimes = new long[Constants.DB_DIVIDER];
                finalCounts = new int[Constants.DB_DIVIDER];
                var overallTableSize = db.ColectionSizes[originalQueryFromWeb.Split('.')[1]];
                for (int i = 0; i < Constants.DB_DIVIDER; i++)
                {
                    initialCounts[i] = (overallTableSize * (i + 1)) / Constants.DB_DIVIDER;
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var list = generatedQueries[i].ToList();
                    stopwatch.Stop();
                    finalCounts[i] = list.Count;
                    executionTimes[i] = stopwatch.ElapsedTicks;
                }
            }
        }

        private IQueryable[] GenerateQueryFromString()
        {
            var tableName = originalQueryFromWeb.Split('.')[1];
            var modifiedQueryFromWeb = originalQueryFromWeb.Substring(originalQueryFromWeb.IndexOf('.', 3));
            // Create the class as usual
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("namespace LINQapi.Helpers");
            sb.AppendLine("{");
            sb.AppendLine("      public class MyQuery");
            sb.AppendLine("      {");
            sb.AppendLine("            public IQueryable[] result(MyDbSet db)");
            sb.AppendLine("            {");
            sb.AppendLine("                 IQueryable[] expressionsSet = new IQueryable[" + Constants.DB_DIVIDER + "];");
            sb.AppendLine("                 for (int i = 0; i < " + Constants.DB_DIVIDER + "; i++)");
            sb.AppendLine("                 {");
            sb.AppendLine("                     int counter = (db." + tableName + ".Count * (i + 1)) / " + Constants.DB_DIVIDER + ";");
            sb.AppendLine("                     var temp = db." + tableName + ".Take(counter).ToList();");
            sb.AppendLine("                     var exp = temp" + modifiedQueryFromWeb + ";");
            sb.AppendLine("                     expressionsSet[i] = exp;");
            sb.AppendLine("                 }");
            sb.AppendLine("                 return expressionsSet;");
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
            IQueryable[] targetValues = classRef.result(db);
            return targetValues;
        }
    }
}