using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Data.dtos;
using TodoApp.Models;

namespace TodoApp.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
public class UserController : ControllerBase
{
    private TodoContext _context;
    private IMapper _mapper;

    public UserController(TodoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDto userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid data");
        }
        User user = _mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
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
