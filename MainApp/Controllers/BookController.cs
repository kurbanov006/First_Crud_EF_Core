using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace MainApp.Controllers;


[ApiController]
[Route("/api/book/")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IResult> Create(Book book)
    {
        if (book == null!)
        {
            return Results.BadRequest("Введите Книгу");
        }

        bool res = await _bookService.Create(book);
        if (res == false)
        {
            return Results.BadRequest("Не удалось добавить!");
        }
        return Results.Ok("Книга успешно добавлена");
    }


    [HttpPut]
    public async Task<IResult> Update(Book book)
    {
        if (book == null!)
        {
            return Results.BadRequest("Введите Книгу");
        }

        bool res = await _bookService.Update(book);
        if (res == false)
        {
            return Results.BadRequest("Не удалось изменить!");
        }
        return Results.Ok("Книга успешно изменена");
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        bool res = await _bookService.Delete(id);
        if (res == false)
        {
            return Results.BadRequest("Не удалось удалить!");
        }
        return Results.Ok("Книга успешно удалена");
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        Book? book = await _bookService.GetById(id);
        if (book == null)
        {
            return Results.NotFound("Книга не найдена");
        }
        return Results.Ok(book);
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
        IEnumerable<Book?> books = await _bookService.GetAll();
        if (books == null!)
        {
            return Results.NotFound("Книги не найдены");
        }
        return Results.Ok(books);
    }
}