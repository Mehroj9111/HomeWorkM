using Dapper;
using Domain.Dto;
using Npgsql;
namespace Infrastructure.Service;
public class AuthorService
{
     private readonly DapperContext _context;

    public AuthorService(DapperContext context)
    {
        _context = context;
    }

    public List<FullInformation> GetAuthor()
    {
        using (var connection = _context.CreateConnection())
        {
            
            var result = connection.Query<FullInformation>("select a.id, a.first_name as FirstName, a.last_name as LastName , b.book_name as BookName from author as a join book as b  on a.id = b.author_id as AuthorId").ToList();
            return result;
        }
    }
    public int InsertAuthor(Author authors)
    {
        using (var connection = _context.CreateConnection())
        {
            var result = connection.Execute($"INSERT INTO author (first_name, last_name  ) VALUES "+
            $"('{authors.FirstName}'," +
            $"'{authors.LastName}')"); 
            return result;
        }
    }
         public int UpdateAuthor(Author authors)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = 
                   $"UPDATE author SET " +
                    $"first_name = '{authors.FirstName}'," +
                    $"last_name = '{authors.LastName}'," +
                    $"where id = '{authors.Id}'" ;
                var result = conn.Execute(sql);

                return result;
            }
        }
    public int DeleteAuthor(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"DELETE FROM author WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
              public Author GeTAuthorById(int id)
 {
       using (var conn = _context.CreateConnection())
        {
            var sql = 
            $"Select * from author where categoryid = {id}";  
            
            return conn.QuerySingleOrDefault<Author>(sql, new {id});
        }
    }   

}