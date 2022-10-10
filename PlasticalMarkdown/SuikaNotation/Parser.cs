using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlasticalMarkdown.SuikaNotation;
class Parser : IMarkdownParser
{
    public Parser(Dictionary<string, ItemType> itemTypes)
    {
        ItemTypes = itemTypes;
    }

    public readonly Dictionary<string, ItemType> ItemTypes = new();
    
    public IEnumerable<MarkdownItem> Parse(MarkdownInfo markdown)
    {
        var lines = markdown.SourceText.Replace("\t", "").Trim().Split('\n') ;
        foreach (var line in lines)
        {
            foreach (var type in ItemTypes)
            {
                Match match = Regex.Match(line, type.Key);
                if (match.Success)
                {
                    yield return new SuikaItemBuilder(line, type.Value).ToSuikaItem();
                }
            }
        }
    }
}
