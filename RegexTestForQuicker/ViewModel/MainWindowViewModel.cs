using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTestForQuicker.ViewModel
{
    class MainWindowViewModel : NotificationObject
    {
        public DelegateCommand ExecuteRegexMatch;
        //正则表达式
        private string _pattern;
        public string Pattern
        {
            get
            {
                return _pattern;
            }
            set
            {
                _pattern = value;
                RaisePropertyChanged("Pattern");
            }
        }

        //元素匹配内容
        private string _input;
        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                RaisePropertyChanged("Input");
            }
        }

        //结果
        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                RaisePropertyChanged("Result");
            }
        }

        //结果列表
        private List<string> _matchesList;
        public List<string> MatchesList
        {
            get { return _matchesList; }
            set
            {
                _matchesList = value;
                RaisePropertyChanged("MatchesList");
            }
        }


        //选项
        //正则匹配模式选项
        private List<RegexOptionItem> _regexOptions;
        public List<RegexOptionItem> RegexOptionItems
        {
            get
            {
                return _regexOptions;
            }
            set
            {
                _regexOptions = value;
                RaisePropertyChanged("RegexOptionItems");
            }
        }

        //是否显示全部匹配项
        private bool _showAllMatches;
        public bool ShowAllMatches
        {
            get
            {
                return _showAllMatches;
            }
            set
            {
                _showAllMatches = value;
                RaisePropertyChanged("ShowAllMatches");
            }
        }


       public MainWindowViewModel()
        {
            LoadRegexOptions();
            ShowAllMatches = false;
            ExecuteRegexMatch = new DelegateCommand(new Action(RegexMatch));
        }

        public void LoadRegexOptions()
        {
            List<RegexOptionItem> RegexOptionItems = new List<RegexOptionItem>();
            RegexOptionItems.Add(new RegexOptionItem() { op = RegexOptions.Singleline });
            RegexOptionItems.Add(new RegexOptionItem() { op = RegexOptions.Multiline });
            RegexOptionItems.Add(new RegexOptionItem() { op = RegexOptions.IgnoreCase });
        }

        public void RegexMatch()
        {
            //显示所以匹配的内容
            if (ShowAllMatches)
            {
                MatchCollection matches = Regex.Matches(this.Input, this.Pattern, 0);
                for (int i = 0; i < matches.Count; i++)
                {
                    string content = $"匹配{i + 1}：{matches[i].Value}\r\n";
                    MatchesList.Add(content);
                }
            }
            //只匹配第一项
            else
            {
                string match = Regex.Match(this.Input, this.Pattern, 0).Value;
                string content = $"匹配1：{match}";
                //MatchesList.Add(content);
                Result = content;
            }
        }
    }
}
