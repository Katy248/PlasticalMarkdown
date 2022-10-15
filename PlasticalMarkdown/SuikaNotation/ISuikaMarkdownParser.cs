using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation;
public interface ISuikaMarkdownParser
{
    IEnumerable<string> Lines { get; }
    int CurrentLineIndex { get; set; }
}
