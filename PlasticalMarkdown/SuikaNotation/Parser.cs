using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace PlasticalMarkdown.SuikaNotation;
public class Parser : IMarkdownParser, ISuikaMarkdownParser
{
    public Parser(MarkdownInfo markdown, Dictionary<string, ItemType>? itemTypes = null)
    {
        this.ItemTypes = itemTypes ?? SuikaItemTypes;
        this.markdown = markdown;
        this.lines = 
            markdown
            .SourceText
            .Replace("\t", "").Replace("\r", "").Trim()
            .Split('\n')
            .Where(_ => !String.IsNullOrWhiteSpace(_))
            .ToArray();
        /**/
    }

    private readonly MarkdownInfo markdown;
    private readonly string[] lines;
    public readonly Dictionary<string, ItemType> ItemTypes;
    private int lineIndex = -1;
    public SuikaItem CurrentItem
    {
        get
        {
            return currentItem ?? throw new ArgumentNullException("Line wasn't parsed yet, there isn't parsed item.");
        }
    }

    private SuikaItem? currentItem;

    public IEnumerable<MarkdownItem> Parse()
    {
        foreach (var line in lines)
            yield return ParseLine(line, ItemTypes);
    }

    public MarkdownItem ParseLine()
    {
        currentItem = ParseLine(lines[lineIndex], ItemTypes);
        return currentItem;
    }

    public MarkdownItem? ParseNext()
    {
        if (++lineIndex >= lines.Length) return null;

        return ParseLine();
    }

    public static readonly Dictionary<string, ItemType> SuikaItemTypes = new()
    {
        {@"\%([\s][\S]+)*", ItemType.Function},
        {@"\:[^\n]+", ItemType.Label},
        {@"", ItemType.TextOutput}
    };

    private static SuikaItem ParseLine(string line, Dictionary<string, ItemType> itemTypes)
    {
        foreach (var type in itemTypes)
        {
            Match match = Regex.Match(line, type.Key);
            if (match.Success)
                return new SuikaItemFactory(line, type.Value).ToSuikaItem();
        }
        return new SuikaItem("");
    }
    public void GoTo(string label)
    {

    }
    #region IMarkdownParser realization
    MarkdownItem IMarkdownParser.CurrentItem => CurrentItem;

    int ISuikaMarkdownParser.CurrentLineIndex { get => lineIndex; set => lineIndex = value; }

    IEnumerable<string> ISuikaMarkdownParser.Lines => lines;

    IEnumerable<MarkdownItem> IMarkdownParser.Parse() => this.Parse();
    MarkdownItem IMarkdownParser.ParseLine() => this.ParseLine();
    MarkdownItem? IMarkdownParser.ParseNext() => this.ParseNext();
    //void IMarkdownParser.GoTo(string mark) => this.GoTo(mark);
    #endregion
}
