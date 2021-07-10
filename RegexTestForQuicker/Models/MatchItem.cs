using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTestForQuicker.Models
{
    class MatchItem
    {
        public string Index { get; set; }  //匹配的第几项
        public string Value { get; set; }  //匹配值
        public MatchItem(string index, string value)
        {
            Index = index;
            Value = value;
        }
    }
}
