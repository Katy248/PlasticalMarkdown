using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation;
public class SuikaItem : MarkdownItem
{
    public SuikaItem(string value, ItemType type) : base(value)
    {
        Type = type;
    }
    public ItemType Type { get; set; }
}
public class FunctionItem : SuikaItem
{
    public FunctionItem(string value, ItemType type) : base(value, type)
    {

    }
}
public class TextItem : SuikaItem
{
    public TextItem(string speech, string speaker, string value, ItemType type) : base(value, type)
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
    public LabelItem(string value, ItemType type) : base(value, type)
    {

    }
}
public enum ItemType
{
    TextOutput,
    Function,
    Label,
}
