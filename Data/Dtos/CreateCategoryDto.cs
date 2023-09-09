using System.ComponentModel.DataAnnotations;

namespace TodoApp.Data.dtos
{
    public class CreateCategoryDto
    {
    [Required(ErrorMessage ="Missing Category")]
    public string CategoryName {get; set;}
    [Required(ErrorMessage ="Missing UserId")]
    public int UserId {get; set;}
    }
}