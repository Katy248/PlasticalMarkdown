using PlasticalMarkdown;
using PlasticalMarkdown.SuikaNotation;
using PlasticalMarkdown.SuikaNotation.Functions;
using PlasticalMarkdown.SuikaNotation.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalNovelWPF;
public class SuikaProcessor
{
    public SuikaProcessor(MarkdownInfo markdownInfo, SuikaFunctionExecuter? functionExecuter = null)
    {
        _parser = new Parser(markdownInfo);
        _functionExecuter = functionExecuter;
        ParsedFunctionItem += ExecuteFunction;
    }
    private readonly ISuikaMarkdownParser _parser;
    public readonly SuikaFunctionExecuter? _functionExecuter;

    private void ExecuteFunction(FunctionItem functionItem)
    {
        _functionExecuter?.ExecuteFunction(functionItem);
    }
    public void Start()
    {
        Next();
    }
    public void Next()
    {
        switch (_parser.ParseNext())
        {
            case TextItem ti: ParsedTextItem?.Invoke(ti);
                break;
            case FunctionItem fi: ParsedFunctionItem?.Invoke(fi); 
                break;
            case null: ScriptEnds?.Invoke(); 
                break;
            default:
                ParserError?.Invoke(_parser.CurrentItem, _parser);
                break;
        }
    }
    public event TextItemHandler ParsedTextItem;
    public event FunctionItemHandler ParsedFunctionItem;
    public event ScriptEndHandler ScriptEnds;
    public event ParseErrorHandler ParserError;
}
public delegate void ScriptEndHandler();
public delegate void TextItemHandler(TextItem textItem);
public delegate void FunctionItemHandler(FunctionItem functionItem);
public delegate void ParseErrorHandler(object parsedItem, ISuikaMarkdownParser parser);
