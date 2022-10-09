using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PlasticalMarkdown.SuikaNotation;
class Parser : IMarkdownParser
{
    public Dictionary<string, ItemType> Items = new();
    public IEnumerable<MarkdownItem> Parse(MarkdownInfo markdown)
    {
        StringBuilder source = new StringBuilder(markdown.SourceText);
        while (source.Length > 0)
        {
            foreach (var item in Items)
            {
                Match match = Regex.Match(source.ToString(), item.Key);
                if (match.Success)
                {
                    yield return new SuikaItem(match.Value, item.Value);
                    source.Remove(0, match.Length);
                    goto Match;
                }
            }
            source.Remove(0, 1);
            Match:;

        }
    }
}
