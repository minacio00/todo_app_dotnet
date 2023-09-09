using System.ComponentModel.DataAnnotations;
using TodoApp.Models;

namespace TodoApp.Data.dtos
{
    public class ReadTaskDto
    {
    public string TaskName {get; set;}
    public bool IsCompleted {get; set;} = false; 
    public int UserId {get; set;}
    public User User {get; set;}
    public int CategoryId {get; set;}
    public Category Category {get; set;}

    }
}