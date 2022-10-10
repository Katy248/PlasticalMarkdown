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
        switch (type)
        {
            case ItemType.TextOutput:
                Match match = Regex.Match(value, @"\*[\n]*\*");
                if (match.Success)
                    Item = new TextItem(value.Replace(match.Value, ""), match.Value, value);
                else
                    Item = new TextItem(value, "", value);
                break;
            case ItemType.Function:
                Item = new FunctionItem(value);
                break;
            case ItemType.Label:
                Item = new LabelItem(value);
                break;
            default:
                break;
        }
    }
    SuikaItem Item;
    public SuikaItem ToSuikaItem()
    {
        return Item;
    }
}
