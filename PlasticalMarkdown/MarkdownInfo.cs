using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown;
public class MarkdownInfo
{
    public IEnumerable<MarkdownItem> Parse(IMarkdownParser parser)
    {
        return parser.Parse(this);
    }
}
