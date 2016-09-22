using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LINQapi.Helpers
{
    class ExpressionGenerator
    {
        public void Execute(string codeToEval, MyDbSet db)
        {
            StringBuilder sb = new StringBuilder();

            // Create the class as usual
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Linq.Expressions;");
            sb.AppendLine();
            sb.AppendLine("namespace LINQapi.Helpers");
            sb.AppendLine("{");
            sb.AppendLine("      class MyQuery");
            sb.AppendLine("      {");
            sb.AppendLine("            public Expression result(MyDbSet db)");
            sb.AppendLine("            {");
            sb.AppendLine("                 return " + codeToEval + ".Expression;");
            sb.AppendLine("            }");
            sb.AppendLine("      }");
            sb.AppendLine("}");

            // The finished code
            string classCode = sb.ToString();

            // Dont need any extra assemblies
            string[] requiredAssemblies = new string[] { };
            dynamic classRef;
            try
            {
                // Pass the class code, the namespace of the class and the list of extra assemblies needed
                classRef = CodeHelper.HelperFunction(classCode, "LINQapi.Helpers.MyQuery", requiredAssemblies);

                // If the compilation process returned an error, then show to the user all errors
                if (classRef is CompilerErrorCollection)
                {
                    StringBuilder sberror = new StringBuilder();
                    foreach (CompilerError error in (CompilerErrorCollection)classRef)
                    {
                        sberror.AppendLine(string.Format("{0}:{1} {2} {3}",
                                           error.Line, error.Column, error.ErrorNumber, error.ErrorText));
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            var targetValues = classRef.result(db);
        }
    }
}