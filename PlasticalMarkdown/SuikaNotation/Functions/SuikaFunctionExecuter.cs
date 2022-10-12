using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation.Functions;

public class SuikaFunctionExecuter
{
    private List<Function> functions = new List<Function>();
    public SuikaFunctionExecuter AddFunction(Function? function)
    {
        if (function is not null)
            functions.Add(function);
        return this;
    }
    public SuikaFunctionExecuter AddFunctions(IEnumerable<Function> functions)
    {
        foreach (var fn in functions)
        {
            AddFunction(fn);
        }
        return this;
    }
    public void ExecuteFunction(FunctionItem functionItem)
    {
        ExecuteFunction(functionItem.Name, functionItem.Args);
    }
    public void ExecuteFunction(string functionName, string[] arguments)
    {
        functions
            .FirstOrDefault(_ => _.Name == functionName)
            ?.FunctionHandler
            .Invoke(arguments);
    }

}
