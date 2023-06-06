using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategorieController
{
    private readonly IWebHostEnvironment _environment;
    private readonly CategorieService _categorieService;

    public CategorieController(IWebHostEnvironment environment, CategorieService categorieService)
    {
        _environment = environment;
        _categorieService = categorieService;
    }

    [HttpGet("ListCategories")]
    public List<CategorieDto> ListCategories()
    {
        return _categorieService.ListCategories();
    }

    [HttpGet("GetById")]
    public CategorieDto GetCategoriesById(int Id)
    {
        return _categorieService.GetCategoriesById(Id);
    }

    [HttpPost("InsertCategories")]
    public CategorieDto AddCategories([FromForm] CategorieDto categorie)
    {
        return _categorieService.AddCategories(categorie);
    }

    [HttpPut("UpdateCategories")]
    public CategorieDto UpdateCategories([FromForm] CategorieDto categorie)
    {
        return _categorieService.UpdateCategories(categorie);
    }

    [HttpDelete("DeleteCategories")]
    public CategorieDto DeleteCategories(CategorieDto categorie)
    {
        return _categorieService.DeleteCategories(categorie);
    }

    [HttpGet("FiltreCategories")]
    public List<CategorieDto> FiltreCategories(string category)
    {
        return _categorieService.FiltreCategories(category);
    }
}
