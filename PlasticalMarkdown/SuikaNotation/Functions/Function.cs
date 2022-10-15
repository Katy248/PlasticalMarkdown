using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation.Functions;

public class Function
{
    public Function(string name, Action<string[]> functionHendler)
    {
        Name = name;
        FunctionHandler = functionHendler;
    }

    private string? name;
    public readonly Action<string[]> FunctionHandler;

    public string Name 
    { 
        get => name ?? ""; 
        private set 
        {
            name = value;
            if (!name.StartsWith('%'))
                name = '%' + name;
        } 
    }
}
