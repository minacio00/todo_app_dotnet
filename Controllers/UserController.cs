using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Data.dtos;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
public class UserController : ControllerBase
{
    private TodoContext _context;
    private IMapper _mapper;
    private PasswordHashService _hasher;

    public UserController(TodoContext context, IMapper mapper, PasswordHashService hasher)
    {
        _context = context;
        _mapper = mapper;
        _hasher = hasher; 
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDto userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid data");
        }
        userDto.Password = _hasher.HashPassword(userDto.Password, out var salt);

        User user = _mapper.Map<User>(userDto);
        user.Salt = Convert.ToHexString(salt);

        _context.Users.Add(user);
        _context.SaveChanges();
        var readUserDto =  _mapper.Map<ReadUserDto>(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, readUserDto);
    }
    [HttpGet]
    public IEnumerable<ReadUserDto> GetAllUsers([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
       return _mapper.Map<List<ReadUserDto>>(_context.Users.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        User user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<ReadUserDto>(user);

        return Ok(userDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
    {

        User existingUser = _context.Users.FirstOrDefault(u => u.Id == id);

        if (existingUser == null)
        {
            return NotFound();
        }

        _mapper.Map(userDto, existingUser);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        User user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}
