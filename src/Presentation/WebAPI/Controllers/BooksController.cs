using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Book.List")]
        public IActionResult GetList()
        {
            var result = _bookService.GetList();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int bookId)
        {
            var result = _bookService.GetById(bookId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _bookService.GetListByCategory(categoryId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Book book)
        {
            var result = _bookService.Add(book);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Book book)
        {
            var result = _bookService.Update(book);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Book book)
        {
            var result = _bookService.Delete(book);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }


    }
}
