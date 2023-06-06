using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class UserSevice
{
    private readonly DapperContext _context;

    public UserSevice(DapperContext context)
    {
        _context = context;
    }

    public List<UserDto> ListUser()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, first_name as FirstName, last_name as LastName, email as Email, phone as Phone, job_id as JobId from users order by id";
            var result = conn.Query<UserDto>(sql).ToList();
            return result;
        }
    }

    public UserDto GetUserById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, first_name as FirstName, last_name as LastName, email as Email, phone as Phone, job_id as JobId from users where id = {Id}";
            var result = conn.QuerySingle<UserDto>(sql, new {Id});
            return result;
        }
    }

    public UserDto AddUser(UserDto user)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into users (first_name, last_name, email, phone, job_id) values (@FirstName, @LastName, @Email, @Phone, @JobId)";
            var result = conn.Execute(sql, user);
            return user;
        }
    }

    public UserDto UpdateUser(UserDto user)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"update users set id = @Id, first_name = @FirstName, last_name = @LastName, email = @Email, phone = @Phone, job_id = @JobId where id = @Id";
            var result = conn.Execute(sql, user);
            return user;
        }
    }

    public UserDto DeleteUsers(UserDto user)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"delete from users where id = @Id";
            var result = conn.Execute(sql, user);
            return user;
        }
    }

    public List<UserDto> FiltreUser(string first_name)
    {
        using(var conn = _context.CreateConnection())
        {
        var sql = $"select id as Id, first_name as FirstName, last_name as LastName, email as Email, phone as Phone, job_id as JobId from users where first_name like '%{first_name}%' ";
        var result = conn.Query<UserDto>(sql).ToList();
        return result;
        }
    }
}
