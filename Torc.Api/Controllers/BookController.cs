using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Torc.BLL.Services;
using Torc.BLL.ViewModel;
using Torc.DAL.EntityFramework;

namespace Torc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookServices _bookServices;

        public BookController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetBook([FromQuery] BookSearchViewModel bookSearch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var books = await _bookServices.Search(bookSearch);

            return Ok(books);
        }
    }
}
