using Domain.Dto;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthorController
{
    private AuthorService _authorService;
    public AuthorController( AuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpGet("Getinfo")]
    public List<FullInformation> GetAuthor()
    {
        return _authorService.GetAuthor();
    }
    [HttpPost("Insert")]
    public int InsertAuthor(Author authors)
    {
        return _authorService.InsertAuthor(authors);
    }

        [HttpPut("Update")]
        public int UpdateAuthor(Author authors)
        {
            return _authorService.UpdateAuthor(authors);
        }
         [HttpDelete("Delete")]
        public int DeleteAuthor(int id)
        {
            return _authorService.DeleteAuthor(id);
        }       

         [HttpGet("GetDepartmentById")]
    public Author GeTAuthorById(int id)
    {
        return _authorService.GeTAuthorById(id);
    }

    }
    
