using System.ComponentModel.DataAnnotations;

namespace TodoApp.Data.dtos
{
    public class ReadCategoryDto
    {
        public string CategoryName { get; set; }
        public int UserId { get; set; }
    }

}