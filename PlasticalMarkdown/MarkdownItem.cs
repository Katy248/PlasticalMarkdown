using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown;
public class MarkdownItem
{
    public MarkdownItem(string value)
    {
        Value = value;
    }
    string Value { get; set; }
}