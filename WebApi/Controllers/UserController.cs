using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController
{
    private readonly IWebHostEnvironment _environment;
    private readonly UserSevice _userSevice;

    public UserController(IWebHostEnvironment environment, UserSevice userSevice)
    {
        _environment = environment;
        _userSevice = userSevice;
    }

    [HttpGet("ListUsers")]
    public List<UserDto> ListUser()
    {
        return _userSevice.ListUser();
    }

    [HttpGet("GetById")]
    public UserDto GetUserById(int Id)
    {
        return _userSevice.GetUserById(Id);
    }

    [HttpPost("InsertUsers")]
    public UserDto AddUser([FromForm] UserDto user)
    {
        return _userSevice.AddUser(user);
    }

    [HttpPut("UpdateUsers")]
    public UserDto UpdateUser([FromForm] UserDto user)
    {
        return _userSevice.UpdateUser(user);
    }

    [HttpDelete("DeleteUsers")]
    public UserDto DeleteUsers( UserDto user)
    {
        return _userSevice.DeleteUsers(user);
    }

    [HttpGet("FiltreUsers")]
    public List<UserDto> FiltreUser( string first_name)
    {
        return _userSevice.FiltreUser(first_name);
    }
}
