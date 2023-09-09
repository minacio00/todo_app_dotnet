using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class User
{
    [Required]
    [Key]
    public int Id {get; set;}
    [Required]
    public string Username {get; set;}

    [Required]
    public string Password {get; set;}

    public ICollection<Category> Categories {get; } = new List<Category>();
}