using RegexTestForQuicker.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RegexTestForQuicker.Converter
{
    class RegexOps2String : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IList<object> items = ((IList<object>)value);
            string flag = "";
            foreach (var ob in items)
            {
                RegexModes item = (RegexModes)ob;
                if (item.Mark == "SingleLine")
                {
                    flag += "S";
                }
                if (item.Mark == "MultiLine")
                {
                    flag += "M";
                }
                if (item.Mark == "Ignorecase")
                {
                    flag += "I";
                }
            }
            return flag;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
