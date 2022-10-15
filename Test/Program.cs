using PlasticalMarkdown;
using PlasticalMarkdown.SuikaNotation;
Console.WriteLine("Start");
//Console.WriteLine($"{Directory.GetCurrentDirectory()}");
var mi = new MarkdownInfo("script.txt");
IMarkdownParser p = new Parser(mi);
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
            Console.WriteLine($"Function {fi.Name}");
            break;
        case LabelItem li:
            Console.WriteLine($"label {li.Label}");
            break;
        default:
			break;
	}
	Console.ForegroundColor = ConsoleColor.White;
}

