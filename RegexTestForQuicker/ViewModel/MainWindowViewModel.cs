﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using RegexTestForQuicker.Models;
using RegexTestForQuicker.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;


namespace RegexTestForQuicker.ViewModel
{
    class MainWindowViewModel : NotificationObject
    {

        public List<RegexModes> PopupItems { get; set; }

        public RegexOptions SelectedRegexOptions { get; set; }  //Regex options user selected
        public DelegateCommand ExecuteRegexMatch { get; set; }

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

        //Display in the result ListBox 
        private ObservableCollection<MatchItem> _ResultList;
        public ObservableCollection<MatchItem> ResultList
        {
            get { return _ResultList; }
            set
            {
                _ResultList = value;
                RaisePropertyChanged("ResultList");
            }
        }

        //是否显示全部匹配项
        private bool _showAllMatches = true;
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
            ExecuteRegexMatch = new DelegateCommand(new Action(RegexMatch));
            PopupItems = LoadRegexOptions();
        }

        public List<RegexModes> LoadRegexOptions()
        {
            List<RegexModes> ops = new List<RegexModes>();
            RegexModes op1 = new RegexModes("Ignorecase", RegexOptions.IgnoreCase, "忽略字母大小写",true);
            RegexModes op2 = new RegexModes("SingleLine", RegexOptions.Singleline, "此模式下英文句号“.”可以匹配换行符\\n，未开启则不能");
            RegexModes op3 = new RegexModes("MultiLine", RegexOptions.Multiline, "此模式下“^”和“$”可以分别匹配段首和段尾，未开启则匹配整个字符串首尾");
            ops.Add(op1);
            ops.Add(op2);
            ops.Add(op3);
            return ops;
        }
        //实行正则匹配
        public void RegexMatch()
        {
            if (String.IsNullOrEmpty(Input) || String.IsNullOrEmpty(Pattern))
            {
                return;
            }

            ObservableCollection<MatchItem> temp = new ObservableCollection<MatchItem>();
            //Input = EditorDocument.Text;
            try
            {
                GetRegxOptions();
                MatchCollection matches = Regex.Matches(this.Input, this.Pattern, SelectedRegexOptions);
                if (matches.Count != 0)
                {
                    if (ShowAllMatches)
                    {
                        for (int i = 0; i < matches.Count; i++)
                        {
                            string index = $"匹配{i + 1}：";
                            temp.Add(new MatchItem(index, matches[i].Value));
                        }
                    }
                    else
                    {
                        temp.Add(new MatchItem("匹配1：", matches[0].Value));
                    }
                }
            }
            //捕获异常
            catch (ArgumentException err)
            {
                string item = "正则解析出错：" + err.Message.Replace("正在分析", "");
                temp.Add(new MatchItem("Error:", item));
            }

            catch (RegexMatchTimeoutException err)
            {
                string item = "正则匹配超时：" + err.Message;
                temp.Add(new MatchItem("Error:", item));
            }

            finally
            {
                ResultList = temp; //触发ResultList的RaisePropertyChanged
            }

        }

        public void GetRegxOptions()
        {
            RegexOptions ops = 0;
            var optionsList = PopupItems.Where(x => x.IsSelected).Select(x => x.Option);
            foreach (var op in optionsList)
            {
                ops = ops | op;
            }
            SelectedRegexOptions = ops;
        }



    }
}
