using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DapperContext _context;

    public JobService(DapperContext context)
    {
        _context = context;
    }

    public List<JobDto> ListJob()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, title as Title, category_id as CategoryId, clousing_date as ClousingDate from jobs order by id";
            var result = conn.Query<JobDto>(sql).ToList();
            return result;
        }
    }

    public JobDto GetJobById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, title as Title, category_id as CategoryId, clousing_date as ClousingDate from jobs where id = {Id}";
            var result = conn.QuerySingle<JobDto>(sql, new {Id});
            return result;
        }
    }

    public JobDto AddJob(JobDto job)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into jobs (title, category_id, clousing_date) values (@Title, @CategoryId, @ClousingDate)";
            var result = conn.Execute(sql, job);
            return job;
        }
    }

    public JobDto UpdateJob(JobDto job)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"update jobs set id = @Id, title = @Title, category_id = @CategoryId, clousing_date = @ClousingDate where id = @Id ";
            var result = conn.Execute(sql, job);
            return job;
        }
    }

    public JobDto DeleteJob(JobDto job)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"delete from jobs where id = @Id";
            var result = conn.Execute(sql, job);
            return job;
        }
    }

    public List<JobDto> FiltreJob(string title)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, title as Title, category_id as CategoryId, clousing_date as ClousingDate from jobs where title like '%{title}%'";
            var result = conn.Query<JobDto>(sql).ToList();
            return result;
        }
    }
}
