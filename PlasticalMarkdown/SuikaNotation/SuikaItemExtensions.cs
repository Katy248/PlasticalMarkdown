using System;

namespace PlasticalMarkdown.SuikaNotation;
public static class SuikaItemExtensions
{
    static void Map(this SuikaItem suikaItem, Action<TextItem> action1, Action<FunctionItem> action2, Action<LabelItem> action3)
    {
        switch (suikaItem)
        {
            case TextItem:
                action1.Invoke(suikaItem as TextItem);
                break;
            case FunctionItem:
                action2.Invoke(suikaItem as FunctionItem);
                break;
            case LabelItem:
                action3.Invoke(suikaItem as LabelItem);
                break;
            default:
                throw new ArgumentException();
        }
    }
    static void BaseMap(this SuikaItem suikaItem, Action<TextItem> textAction, Functions.SuikaFunctionExecuter functionExecuter, Action<LabelItem> labelAction)
    {
        Map(suikaItem, textAction, item => { }, labelAction);
    }
}
