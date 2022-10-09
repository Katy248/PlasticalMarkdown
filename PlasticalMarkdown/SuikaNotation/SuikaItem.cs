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
public enum ItemType
{
    TextOutput,
    Function,
    Label,
}
