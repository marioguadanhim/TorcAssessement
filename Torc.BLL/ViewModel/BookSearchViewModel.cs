using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torc.BLL.ViewModel
{
    public class BookSearchViewModel
    {
        [StringLength(50, ErrorMessage = "Name length can't exceed 50 characters.")]
        public string SearchBy { get; set; }

        [StringLength(200, ErrorMessage = "Name length can't exceed 200 characters.")]
        public string SearchValue { get; set; }
    }
}
