using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown;
public interface IMarkdownParser
{
    /// <summary>
    /// Parse all file.
    /// </summary>
    /// <returns><see cref="IEnumerable{MarkdownInfo}"/> of parsed <see cref="MarkdownItem"/>.</returns>
    IEnumerable<MarkdownItem> Parse();
    /// <summary>
    /// Parse line.
    /// </summary>
    /// <returns>Parsed <see cref="MarkdownItem"/>.</returns>
    MarkdownItem ParseLine();
    /// <summary>
    /// Parse next line.
    /// </summary>
    /// <returns>If next line exists then parsed <see cref="MarkdownItem"/> else <see cref="null"/>.</returns>
    MarkdownItem? ParseNext();
    /// <summary>
    /// Get current parsed <see cref="MarkdownItem"/>.
    /// </summary>
    MarkdownItem CurrentItem { get; }
    void GoTo(string mark);
}
