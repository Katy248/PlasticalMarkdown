using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation.Labels;
public class LabelTransferer
{
    public LabelTransferer(ISuikaMarkdownParser suikaParser)
    {
        parser = suikaParser;
        var lines = parser.Lines.ToArray();

        //fill labels
        for (int i = 0; i < lines.Length; i++)
            if (lines[i].Trim().StartsWith(':'))
                labels.Add(lines[i].Remove(0, 1), i);
    }
    private readonly ISuikaMarkdownParser parser;
    private Dictionary<string, int> labels = new Dictionary<string, int>();
    public void SetPosition(string label)
    {
        if (labels.TryGetValue(label, out int newPosition))
        {
            parser.CurrentLineIndex = newPosition;
        }
    }
}
