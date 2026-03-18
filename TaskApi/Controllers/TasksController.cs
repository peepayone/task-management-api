using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        //查詢全部 可帶參數query string
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? status)
        {
            var query = _context.Tasks.AsQueryable();
            //如果有參數 帶出附帶條件的查詢
            if(!string.IsNullOrWhiteSpace(status)) query = query.Where(t => t.Status == status);

            //依照創立時間帶出全部查詢
            var result = query
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    CreatedAt = t.CreatedAt
                })
                .ToList();

            return Ok(result);
        }

        //查詢BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _context.Tasks.Find(id);
            if(task == null) return NotFound();

            var result = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt
            };

            return Ok(result);
        }

        //新增
        [HttpPost]
        public IActionResult Create(CreateTaskDto taskDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
                CreatedAt = DateTime.Now
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();

            var result = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt
            };

            return Ok(result);
        }

        //刪除
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }

        //修改
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTaskDto taskDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Status = taskDto.Status;

            _context.SaveChanges();

            return NoContent();
        }
    }
}