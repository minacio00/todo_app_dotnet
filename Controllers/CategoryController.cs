using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Data.dtos;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public CategoryController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            List<ReadCategoryDto> categoryDtos = _mapper.Map<List<ReadCategoryDto>>(categories);
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            ReadCategoryDto categoryDto = _mapper.Map<ReadCategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
            {
                return BadRequest("Invalid data");
            }

            Category category = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(category);
            _context.SaveChanges();

            ReadCategoryDto categoryDto = _mapper.Map<ReadCategoryDto>(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            Category existingCategory = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryDto, existingCategory);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}