using Microsoft.Practices.Prism.ViewModel;
using System.Text.RegularExpressions;

namespace RegexTestForQuicker.ViewModel
{
    class RegexOptionItem : NotificationObject
    {
        public RegexOptions op { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
    }
}
