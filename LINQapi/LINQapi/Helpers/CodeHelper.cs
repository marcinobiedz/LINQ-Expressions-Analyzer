using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.CSharp;
using System;

namespace LINQapi.Helpers
{
    public class CodeHelper
    {
        public static object HelperFunction(string classCode, string mainClass, string[] requiredAssemblies)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } });
            CompilerParameters parameters = new CompilerParameters
            {
                GenerateExecutable = false,       // Create a dll
                GenerateInMemory = true,          // Create it in memory
                WarningLevel = 3,                 // Default warning level
                CompilerOptions = "/optimize",    // Optimize code
                TreatWarningsAsErrors = false     // Better be false to avoid break in warnings
            };

            // Add basic referenced assemblies
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            parameters.ReferencedAssemblies.Add(currentDir + @"\bin\LINQapi.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Data.Linq.dll");
            parameters.ReferencedAssemblies.Add("System.Data.Entity.dll");
            parameters.ReferencedAssemblies.Add(currentDir + @"\bin\EntityFramework.dll");

            // Add all extra assemblies required
            foreach (var extraAsm in requiredAssemblies)
            {
                parameters.ReferencedAssemblies.Add(extraAsm);
            }

            // Try to compile the code received
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, classCode);

            // If the compilation returned error, then return the CompilerErrorCollection class 
            // with the errors to the caller
            if (results.Errors.Count != 0)
            {
                return results.Errors;
            }

            // Return the created class instance to caller
            return results.CompiledAssembly.CreateInstance(mainClass); ;
        }
    }
}