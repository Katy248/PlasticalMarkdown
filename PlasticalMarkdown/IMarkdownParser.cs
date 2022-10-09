using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown;
public interface IMarkdownParser
{
    IEnumerable<MarkdownItem> Parse(MarkdownInfo markdown);
}
