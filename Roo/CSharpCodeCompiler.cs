using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace Roo.Compile
{
    public class CSharpCodeCompiler
    {
        public CSharpCodeCompiler()
        {

        }
        public Assembly Compile(string code)
        {
            //get the code to compile

            string strSourceCode = code;

            

            // 1.Create a new CSharpCodePrivoder instance

            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

            

            // 2.Sets the runtime compiling parameters by crating a new CompilerParameters instance

            CompilerParameters objCompilerParameters = new CompilerParameters();

            objCompilerParameters.ReferencedAssemblies.Add("System.dll");

            objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            objCompilerParameters.ReferencedAssemblies.Add("Roo.dll");

            objCompilerParameters.GenerateInMemory = true;



            // 3.CompilerResults: Complile the code snippet by calling a method from the provider

            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromSource(objCompilerParameters, strSourceCode);



            if (cr.Errors.HasErrors)
            {

                string strErrorMsg = cr.Errors.Count.ToString() + " Errors:";



                for (int x = 0; x < cr.Errors.Count; x++)
                {

                    strErrorMsg = strErrorMsg + "/r/nLine: " +

                                 cr.Errors[x].Line.ToString() + " - " +

                                 cr.Errors[x].ErrorText;

                }
                throw new Exception(strErrorMsg);
            }
            else
                return cr.CompiledAssembly;
        }
    }
}