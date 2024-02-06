using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Torc.BLL.Services;
using Torc.BLL.ViewModel;

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
        public IActionResult GetBook([FromQuery] BookSearchViewModel bookSearch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookServices.Search(bookSearch);

            return Ok();
        }
    }
}
