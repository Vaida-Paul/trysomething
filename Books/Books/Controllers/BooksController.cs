using Books.Models.DTOs;
using Books.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Books.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetUserId();
            var books = await _bookService.GetAllAsync(userId);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = GetUserId();
            var book = await _bookService.GetByIdAsync(id, userId);
            if (book == null)
            {
                return Problem(
                        title: "Book not found",
                        statusCode: StatusCodes.Status404NotFound,
                        detail: $"Book with id {id} does not exist"
                );
            }
            return Ok(book);

        }
        
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDTO bookDto)
        {
            var userId = GetUserId();
            var createdBook = await _bookService.CreateAsync(bookDto, userId);

            return CreatedAtAction(nameof(GetById),new { id = createdBook.Id },createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookUpdateDTO bookDto)
        {
            var userId = GetUserId();
            var result = await _bookService.UpdateAsync(id, bookDto, userId);
            if (!result)
            {
                 return Problem(
                        title: "Book not found",
                        statusCode: StatusCodes.Status404NotFound,
                        detail: $"Book with id {id} was not found"
                 );
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            var result = await _bookService.DeleteAsync(id, userId);
            if (!result)
            {
                return Problem(
                    title: "Book not found",
                    statusCode: StatusCodes.Status404NotFound,
                    detail: $"Book with id {id} was not found"
                );
            }
            return NoContent();
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

    }
}
