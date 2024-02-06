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

        public async Task<List<BookSearchResultViewModel>> Search(BookSearchViewModel bookSearchViewModel)
        {
            ValidateSearch(bookSearchViewModel.SearchBy);

            var books = await _bookRepository.GetBooks(bookSearchViewModel.SearchBy, bookSearchViewModel.SearchValue);

            var bookSearchResult = MapEntityToViewModel(books);

            return bookSearchResult;
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

        private List<BookSearchResultViewModel> MapEntityToViewModel(IEnumerable<Book> books)
        {
            var bookSearchResult = new List<BookSearchResultViewModel>();
            foreach (Book book in books)
            {

                bookSearchResult.Add(new BookSearchResultViewModel()
                {
                    BookTitle = book.title,
                    Publisher = "Publish was not informed in SQL script?",
                    Authors = book.first_name + " " + book.last_name,
                    Type = book.type,
                    ISBN = Convert.ToInt64(book.isbn),
                    Category = book.category,
                    AvailableCopies = book.copies_in_use + "/" + book.total_copies
                });

            }

            return bookSearchResult;
        }


    }
}
