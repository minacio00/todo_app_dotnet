using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;


public class Category
{
    [Required]
    [Key]
    public int Id {get; set;}

    [Required(ErrorMessage ="Missing Category")]
    public string CategoryName {get; set;}

    [Required(ErrorMessage ="Missing UserId")]
    public int UserId {get; set;}
    public User User {get; set;} = null!; 
    public ICollection<Task> Tasks {get; } = new List<Task>();
}