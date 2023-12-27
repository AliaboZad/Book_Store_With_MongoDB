using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_Asp.netAPI.Model;
using MongoDB_Asp.netAPI.Services;

namespace MongoDB_Asp.netAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksServices _services;
        public BooksController(BooksServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll ()
            => await _services.GetAsync();

        [HttpGet]
        [Route("OneBook")]
        public async Task< ActionResult<Book>> Get (string id)
        {
            var book = await _services.Getone(id);
            
            if (book == null)
            {
                return NotFound($"this ID is not exist {id}");
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            await _services.CreatAsync(book);
            return Ok("Post Done");
        }

        [HttpPut]
        public async Task<IActionResult> Put (string id , Book book)
        {
            var b = await _services.Getone(id);
            if (b != null && b.Id == book.Id)
            {
                await _services.UpdateAsync(id, book);
                return NoContent();
            }

            return NotFound($"this ID is not exist {id}");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletBook(string id)
        {
            var delete = await _services.Getone(id);
            if (delete != null && delete.Id == id)
            {
                await _services.RemoveAsync(id);
                return NoContent();
            }
            return NotFound($"this ID is not exist {id}");
        }

    }
}
