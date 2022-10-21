using PlasticalMarkdown;
using PlasticalMarkdown.SuikaNotation;
using PlasticalMarkdown.SuikaNotation.Functions;
using PlasticalMarkdown.SuikaNotation.Labels;
using PlasticalMarkdown.SuikaNotation.Saves;

Console.WriteLine("Start");
//Console.WriteLine($"{Directory.GetCurrentDirectory()}");
var mi = new MarkdownInfo("script.txt");
IMarkdownParser p = new Parser(mi);
var fe = new SuikaFunctionExecuter();
var lt = new LabelTransferer((ISuikaMarkdownParser)p);
var save = new Save() { LineIndex = 3 };
lt.SetPosition(save.LineIndex-1);
fe.AddFunction(new Function("цвет", x => { Console.BackgroundColor = (ConsoleColor)int.Parse(x.First()); }));
fe.AddFunction(
	new Function("к-метке", x => { lt.SetPosition(x.First()); }));

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

class Save: SaveItem
{
	public DateTime SaveTime;
}