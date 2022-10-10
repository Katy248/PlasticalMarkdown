﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticalMarkdown.SuikaNotation;
public class SuikaItem : MarkdownItem
{
    public SuikaItem(string value) : base(value)
    {
    }
}
public class FunctionItem : SuikaItem
{
    public FunctionItem(string value) : base(value)
    {

    }
}
public class TextItem : SuikaItem
{
    public TextItem(string speech, string speaker, string value) : base(value)
    {
        Speech = speech;
        Speaker = speaker;
    }
    public string Speech { get; private set; }
    private string? speaker;
    public string Speaker 
    {
        get => speaker ?? ""; 
        private set => speaker = value; 
    }
}
public class LabelItem : SuikaItem
{
    public LabelItem(string value) : base(value)
    {

    }
}
public enum ItemType
{
    TextOutput,
    Function,
    Label,
}
