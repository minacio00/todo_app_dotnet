using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;


public class Task
{
    [Required]
    [Key]
    public int Id {get; set;}

    [Required(ErrorMessage ="Missing taskname")]
    public string TaskName {get; set;}
    public bool IsCompleted {get; set;} = false; 
    [Required(ErrorMessage ="Missing userId")]
    public int UserId {get; set;}
    public User User {get; set;}

    [Required(ErrorMessage ="Missing categoryId")]
    public int CategoryId {get; set;}
    public Category Category {get; set;}

}