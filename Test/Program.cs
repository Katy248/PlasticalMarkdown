using PlasticalMarkdown;
using PlasticalMarkdown.SuikaNotation;
using PlasticalMarkdown.SuikaNotation.Functions;

Console.WriteLine("Start");
//Console.WriteLine($"{Directory.GetCurrentDirectory()}");
var mi = new MarkdownInfo("script.txt");
IMarkdownParser p = new Parser(mi);
var fe = new SuikaFunctionExecuter();
fe.AddFunction(new Function("цвет", x => { Console.BackgroundColor = (ConsoleColor)int.Parse(x.First()); }));
fe.AddFunction(
	new Function("к-метке", 
	x=>
	{

	})
	);
while (p.ParseNext() is not null)
{
	switch (p.CurrentItem)
	{
		case TextItem ti:
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{ti.Speaker}: {ti.Speech}");
			Console.ReadLine();
			break;
        case FunctionItem fi:
			//Console.WriteLine(fi.Args.First());
			fe.ExecuteFunction(fi);
            break;
        case LabelItem li:
            Console.WriteLine($"label {li.Label}");
            break;
        default:
			break;
	}
	Console.ForegroundColor = ConsoleColor.White;
}

