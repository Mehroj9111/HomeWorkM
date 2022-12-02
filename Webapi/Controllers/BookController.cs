using Domain.Dto;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BookController
{
    private BookService _bookService;
    public BookController( BookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet("Getinfo")]
    public List<FullInformation> GetBook()
    {
        return _bookService.GetBook();
    }
    [HttpPost("Insert")]
    public int InsertBook(Book authors)
    {
        return _bookService.InsertBook(authors);
    }

        [HttpPut("Update")]
        public int UpdateBook(Book authors)
        {
            return _bookService.UpdateBook(authors);
        }
         [HttpDelete("Delete")]
        public int DeleteBook(int id)
        {
            return _bookService.DeleteBook(id);
        }       

         [HttpGet("GetDepartmentById")]
    public Book GeTBookById(int id)
    {
        return _bookService.GeTBookById(id);
    }

    }
    
