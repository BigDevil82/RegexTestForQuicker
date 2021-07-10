using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTestForQuicker.Models
{
   public class RegexModes
    {
        public string Mark{ get; set; }
        public RegexOptions Option { get; set; }
        public string Descriptions { get; set; }

        public bool IsSelected { get; set; }
        public RegexModes(string mark,RegexOptions option,string desription,bool? isSelected=false)
        {
            Mark = mark;
            Option = option;
            Descriptions = desription;
            IsSelected = false;
        }
    }
}
