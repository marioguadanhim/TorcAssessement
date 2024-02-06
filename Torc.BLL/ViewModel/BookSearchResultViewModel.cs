using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torc.BLL.ViewModel
{
    public class BookSearchResultViewModel
    {
        public string BookTitle { get; set; }
        public string Publisher { get; set; }
        public string Authors { get; set; }
        public string Type { get; set; }
        public long ISBN { get; set; }
        public string Category { get; set; }
        public string AvailableCopies { get; set; }
    }
}
