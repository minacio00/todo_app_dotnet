using System.ComponentModel.DataAnnotations;

namespace TodoApp.Data.dtos
{
    public class UpdateTaskDto
    {
    [Required(ErrorMessage ="Missing taskname")]
    public string TaskName {get; set;}
    public bool IsCompleted {get; set;} = false; 
    [Required(ErrorMessage ="Missing userId")]
    public int UserId {get; set;}
    [Required(ErrorMessage ="Missing categoryId")]
    public int CategoryId {get; set;}
    }
}