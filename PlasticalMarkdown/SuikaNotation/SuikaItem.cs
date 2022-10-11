using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation;
public class SuikaItem : MarkdownItem
{
    public SuikaItem(string value) : base(value)
    {
    }
}
public class FunctionItem : SuikaItem
{
    public FunctionItem(string name, string[] args, string value) : base(value)
    {
        Name = name;
        Args = args;
    }
    public readonly string Name;
    public readonly string[] Args;
}
public class TextItem : SuikaItem
{
    public TextItem(string speech, string speaker, string value) : base(value)
    {
        Speech = speech;
        Speaker = speaker;
    }
    public string Speech { get; private set; }
    private string? speaker;
    public string Speaker 
    {
        get => speaker ?? ""; 
        private set => speaker = value; 
    }
}
public class LabelItem : SuikaItem
{
    public LabelItem(string label, string value) : base(value)
    {
        Label = label;
    }
    public readonly string Label;
}
public enum ItemType
{
    TextOutput,
    Function,
    Label,
}
