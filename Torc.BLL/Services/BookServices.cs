using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torc.BLL.ViewModel;

namespace Torc.BLL.Services
{
    public class BookServices
    {
        public void Search(BookSearchViewModel bookSearchViewModel)
        {
            Console.WriteLine(bookSearchViewModel);
        }
    }
}
