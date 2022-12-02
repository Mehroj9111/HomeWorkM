using Dapper;
using Domain.Dto;
using Npgsql;
namespace Infrastructure.Service;
public class BookService
{
     private readonly DapperContext _context;

    public BookService(DapperContext context)
    {
        _context = context;
    }

    public List<FullInformation> GetBook()
    {
        using (var connection = _context.CreateConnection())
        {   
            var result = connection.Query<FullInformation>("select  b.id, b.book_name, CONCAT(first_name ,' ',last_name) as AuthorFullName from book as b join author as a  on b.author_id = a.id ").ToList();
            return result;
        }
    }
    public int InsertBook(Book books)
    {
        using (var connection = _context.CreateConnection())
        {
            var result = connection.Execute($"INSERT INTO book (book_name , author_id ) VALUES "+
            $"('{books.BookName}',"+
            $"{books.AutorId})");
            return result;
        }
    }
         public int UpdateBook(Book books)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = 
                   $"UPDATE book SET " +
                    $"book_name = '{books.BookName}'," +
                    $"author_id = '{books.AutorId}'," +
                    $"where id = {books.Id}" ;
                var result = conn.Execute(sql);

                return result;
            }
        }
    public int DeleteBook(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"DELETE FROM book WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
              public Book GeTBookById(int id)
 {
       using (var conn = _context.CreateConnection())
        {
            var sql = 
            $"Select * from book where categoryid = {id}";  
            
            return conn.QuerySingleOrDefault<Book>(sql, new {id});
        }
    }   

}