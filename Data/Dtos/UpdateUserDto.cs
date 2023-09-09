using System.ComponentModel.DataAnnotations;

namespace TodoApp.Data.dtos;

public class UpdateUserDto
{
    [Required(ErrorMessage ="Username is required")]
    public string UserName {get; set;}

    [Required]
    public string Password {get; set;}

}