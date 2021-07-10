using ICSharpCode.AvalonEdit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTestForQuicker.Models
{
    class Results : ISearchResult
    {
        public Match Match;
        public Results(Match m)
        {
            Match = m;
        }
        public int Offset => Match.Index;

        public int Length => Match.Length;

        public int EndOffset => Offset+Length;

        public string ReplaceWith(string replacement)
        {
            return "";
        }
    }
}
