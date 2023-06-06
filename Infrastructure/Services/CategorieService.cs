using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class CategorieService
{
    private readonly DapperContext _context;

    public CategorieService(DapperContext context)
    {
        _context = context;
    }

    public List<CategorieDto> ListCategories()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, category_name as CategoryName from categories order by id";
            var result = conn.Query<CategorieDto>(sql).ToList();
            return result;
        }
    }

    public CategorieDto GetCategoriesById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, category_name as CategoryName from categories where id = {Id}";
            var result = conn.QuerySingle<CategorieDto>(sql, new {Id});
            return result;
        }
    }

    public CategorieDto AddCategories(CategorieDto categorie)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into categories (category_name) values (@CategoryName)";
            var result = conn.Execute(sql, categorie);
            return categorie;
        }
    }

    public CategorieDto UpdateCategories(CategorieDto categorie)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update categories set id = @Id, category_name = @CategoryName where id = @Id ";
            var result = conn.Execute(sql, categorie);
            return categorie;
        }
    }

    public CategorieDto DeleteCategories(CategorieDto categorie)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from categories where id= @Id";
            var result = conn.Execute(sql, categorie);
            return categorie;
        }
    }

    public List<CategorieDto> FiltreCategories(string category)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, category_name as CategoryName from categories where category_name like '%{category}%'";
            var result = conn.Query<CategorieDto>(sql).ToList();
            return result;
        }
    }

}
