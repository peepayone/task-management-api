using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;
using TaskApi.Services.Interfaces;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        //private readonly AppDbContext _context;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        //查詢全部 可帶參數query string
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? status)
        {
            var result = _taskService.GetAll(status);

            return Ok(result);
        }

        //查詢BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _taskService.GetById(id);

            return result == null ? NotFound() : Ok(result);
        }

        //新增
        [HttpPost]
        public IActionResult Create(CreateTaskDto taskDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var result = _taskService.Create(taskDto);

            return Ok(result);
        }

        //修改
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTaskDto taskDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = _taskService.Update(id, taskDto);

            return updated? NoContent() : NotFound();
        }

        //刪除
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _taskService.Delete(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}