using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Data.dtos;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TaskController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            List<Models.Task> tasks = _context.Tasks.ToList();
            List<ReadTaskDto> taskDtos = _mapper.Map<List<ReadTaskDto>>(tasks);
            return Ok(taskDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            Models.Task task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            ReadTaskDto taskDto = _mapper.Map<ReadTaskDto>(task);
            return Ok(taskDto);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            if (createTaskDto == null)
            {
                return BadRequest("Invalid data");
            }

            Models.Task task = _mapper.Map<Models.Task>(createTaskDto);
            _context.Tasks.Add(task);
            _context.SaveChanges();

            ReadTaskDto taskDto = _mapper.Map<ReadTaskDto>(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, taskDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            Models.Task existingTask = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (existingTask == null)
            {
                return NotFound();
            }

            _mapper.Map(updateTaskDto, existingTask);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            Models.Task task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}