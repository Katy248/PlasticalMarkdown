using PlasticalMarkdown.SuikaNotation.Functions;
using PlasticalMarkdown.SuikaNotation.Labels;
using PlasticalMarkdown.SuikaNotation;
using PlasticalMarkdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlasticalNovelWPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var mi = new MarkdownInfo("script.txt");
        processor = new SuikaProcessor(mi);

        processor.ParsedTextItem += ShowText;
        processor.ScriptEnds += EndHandler;
    }
    private readonly SuikaProcessor processor;

    void ShowText(TextItem textItem)
    {
        SpeakerBlock.Text = textItem.Speaker.Trim();
        SpeechBlock.Text = textItem.Speech.Trim();
    }
    void EndHandler()
    {
        MessageBox.Show("This is the End!");
    }

    private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
    {
        processor.Next();
    }
}
