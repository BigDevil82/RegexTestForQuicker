using RegexTestForQuicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegexTestForQuicker.Views
{
    /// <summary>
    /// SelectRegexModes.xaml 的交互逻辑
    /// </summary>
    public partial class SelectRegexModes : Window
    {
        public SelectRegexModes()
        {
            InitializeComponent();
            RegexListBox.ItemsSource = LoadRegexOptions();
            listbox3.ItemsSource = LoadRegexOptions();
            Deactivated += SelectRegexModes_Deactivated;
        }

        private void SelectRegexModes_Deactivated(object sender, EventArgs e)
        {
            base.Close();
        }

        public List<RegexModes> LoadRegexOptions()
        {
            List<RegexModes> ops = new List<RegexModes>();
            RegexModes op1 = new RegexModes("Ignorecase", RegexOptions.IgnoreCase, "忽略字母大小写");
            RegexModes op2 = new RegexModes("SingleLine", RegexOptions.Singleline, "此模式下英文句号“.”可以匹配换行符\\n，未开启则不能");
            RegexModes op3 = new RegexModes("MultiLine", RegexOptions.Multiline, "此模式下“^”和“$”可以分别匹配段首和段尾，未开启则匹配整个字符串首尾");
            ops.Add(op1);
            ops.Add(op2);
            ops.Add(op3);
            return ops;
        }
    }
}
