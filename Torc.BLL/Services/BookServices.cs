using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Torc.BLL.ViewModel;
using Torc.DAL.EntityFramework;
using Torc.DAL.Repository;

namespace Torc.BLL.Services
{
    public class BookServices
    {
        private BookRepository _bookRepository;

        public BookServices(
            BookRepository bookRepository
            )
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> Search(BookSearchViewModel bookSearchViewModel)
        {
            ValidateSearch(bookSearchViewModel.SearchBy);

            var books = await _bookRepository.GetBooks(bookSearchViewModel.SearchBy, bookSearchViewModel.SearchValue);
            return books;
        }


        private bool ValidateSearch(string propertyName)
        {
            PropertyInfo[] properties = typeof(Book).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == propertyName)
                {
                    return true;
                }
            }

            throw new Exception("Invalid Search");
        }


    }
}
