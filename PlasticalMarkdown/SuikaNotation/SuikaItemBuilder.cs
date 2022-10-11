using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation;
public class SuikaItemBuilder
{
    public SuikaItemBuilder(string value, ItemType type)
    {
        this.value = value;
        this.type = type;
    }

    private readonly string value;
    private readonly ItemType type;
    
    private SuikaItem? item;

    public SuikaItem ToSuikaItem()
    {
        switch (type)
        {
            case ItemType.TextOutput:
                Match match = Regex.Match(value, @"\*[\n]*\*");
                if (match.Success)
                    item = new TextItem(value.Replace(match.Value, ""), match.Value, value);
                else
                    item = new TextItem(value, "", value);
                break;
            case ItemType.Function:
                item = new FunctionItem(value);
                break;
            case ItemType.Label:
                item = new LabelItem(value);
                break;
            default:
                break;
        }
        return item;
    }
}
