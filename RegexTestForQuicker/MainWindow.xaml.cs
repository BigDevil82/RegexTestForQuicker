using HandyControl.Controls;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using RegexTestForQuicker.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RegexTestForQuicker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            //List<string> datalist = new List<string>() { "单行", "多行", "忽略大小写" };
            //this.combobox.ItemsSource = datalist;

        }

    //    private void Input_Changed(object sender, TextChangedEventArgs e)
    //    {
    //        RegexOptions op = GetRegexOptions();
    //        ExecTest(op);

    //    }

    //    private void SelectSomeRegexOp(object sender, RoutedEventArgs e)
    //    {
    //        RegexOptions op = GetRegexOptions();
    //        ExecTest(op);

    //    }

    //    /// <summary>
    //    /// 按照不同的正则模式进行正则匹配
    //    /// </summary>
    //    /// <param name="op">正则匹配模式</param>
    //    public void ExecTest(RegexOptions op)
    //    {
    //        if (this.pattern.Text != "" && this.input.Text != "")
    //        {
    //            try
    //            {
    //                RegexMatch((bool)this.showAllMatches.IsChecked, op);

    //            }
    //            catch (ArgumentException err)
    //            {
    //                string item = "正则解析出错：" + err.Message.Replace("正在分析", "");
    //                (this.result.ItemsSource as List<string>).Add(item);
    //            }
    //            catch (RegexMatchTimeoutException err)
    //            {
    //                string item = "正则匹配超时：" + err.Message;
    //                (this.result.ItemsSource as List<string>).Add(item);
    //            }
    //        }
    //    }


    //    /// <summary>
    //    /// 正则匹配，并更新结果框
    //    /// </summary>
    //    /// <param name="showAllMatches">是否显示全部匹配</param>
    //    /// <param name="op">正则匹配模式</param>
    //    public void RegexMatch(bool showAllMatches, RegexOptions op)
    //    {
    //        List<string> items = new List<string>();
    //        //显示所以匹配的内容
    //        if (showAllMatches)
    //        {
    //            MatchCollection matches = Regex.Matches(this.input.Text, this.pattern.Text, op);
    //            for (int i = 0; i < matches.Count; i++)
    //            {
    //                string content = $"匹配{i + 1}：{matches[i].Value}\r\n";
    //                items.Add(content);
    //            }
    //        }
    //        //只匹配第一项
    //        else
    //        {
    //            string match = Regex.Match(this.input.Text, this.pattern.Text, op).Value;
    //            string content = $"匹配1：{match}";
    //            items.Add(content);
    //        }
    //        this.result.ItemsSource = items;

    //        //高亮匹配到的内容
    //        Hightlight(items);
    //    }


    //    /// <summary>
    //    /// 高亮匹配列表
    //    /// </summary>
    //    /// <param name="matches">匹配内容列表</param>
    //    public void Hightlight(List<string> matches)
    //    {
    //        foreach (var match in matches)
    //        {
    //            this.input.TextArea.TextView.LineTransformers.Add(new MarkSameWord(match));
    //        }
    //    }


    //    /// <summary>
    //    /// 获取正则匹配模式
    //    /// </summary>
    //    /// <returns></returns>
    //    public RegexOptions GetRegexOptions()
    //    {
            
    //        RegexOptions op = 0;
    //        List<string> regexOps = this.combobox.SelectedItems as List<string>;
    //        if (regexOps == null)
    //            return op;

    //        if (regexOps.Contains("单行"))
    //        {
    //            op = op | RegexOptions.Singleline;
    //        }
    //        if (regexOps.Contains("多行"))
    //        {
    //            op = op | RegexOptions.Multiline;
    //        }
    //        if (regexOps.Contains("忽略大小写"))
    //        {
    //            op = op | RegexOptions.IgnoreCase;
    //        }
    //        return op;
    //    }

    //    private void input_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    //    {
    //        RegexOptions op = GetRegexOptions();
    //        ExecTest(op);
    //    }

    //    private void input_TextChanged(object sender, EventArgs e)
    //    {
    //        RegexOptions op = GetRegexOptions();
    //        ExecTest(op);
    //    }
    //}


    ///// <summary>
    ///// 高亮AvalonEditor中的某些文字
    ///// </summary>
    //public class MarkSameWord : DocumentColorizingTransformer
    //{
    //    private readonly string _selectedText;

    //    public MarkSameWord(string selectedText)
    //    {
    //        _selectedText = selectedText;
    //    }

    //    protected override void ColorizeLine(DocumentLine line)
    //    {
    //        if (string.IsNullOrEmpty(_selectedText))
    //        {
    //            return;
    //        }

    //        int lineStartOffset = line.Offset;
    //        string text = CurrentContext.Document.GetText(line);
    //        int start = 0;
    //        int index;

    //        while ((index = text.IndexOf(_selectedText, start, StringComparison.Ordinal)) >= 0)
    //        {
    //            ChangeLinePart(
    //              lineStartOffset + index, // startOffset
    //              lineStartOffset + index + _selectedText.Length, // endOffset
    //              element => element.TextRunProperties.SetBackgroundBrush(Brushes.LightSkyBlue));
    //            start = index + 1; // search for next occurrence
    //        }
    //    }
    }

}

