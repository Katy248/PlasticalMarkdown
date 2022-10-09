using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown;
public class MarkdownInfo
{
     #region Constructors

    public MarkdownInfo(string path)
    {
        File = new FileInfo(path);
    }
    public MarkdownInfo(FileInfo file)
    {
        File = file;
    }

    #endregion

    public FileInfo File 
    {
        get => file ?? new FileInfo("");
        private set
        {
            file = value;
            if (!file.Exists)
                throw new FileNotFoundException($"File \"{file.FullName}\" doesn't exist.");
        }
    }

    private FileInfo? file;

    public IEnumerable<MarkdownItem> Parse(IMarkdownParser parser)
    {
        return parser.Parse(this);
    }
}
