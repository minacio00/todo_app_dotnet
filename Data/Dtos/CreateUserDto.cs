using System.ComponentModel.DataAnnotations;
using TodoApp.Models;

namespace TodoApp.Data.dtos;

public class CreateUserDto
{
    [Required(ErrorMessage ="Username is required")]
    public string UserName {get; set;}
    [Required(ErrorMessage ="Password is required")]
    public string Password {get; set;}

    public ICollection<Category> Categories {get; } = new List<Category>();
}