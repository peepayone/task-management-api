using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Services.Interfaces;

namespace TaskApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskDto> GetAll(string? status)
        {
            var query = _context.Tasks.AsQueryable();
            //如果有參數 帶出附帶條件的查詢
            if (!string.IsNullOrWhiteSpace(status)) query = query.Where(t => t.Status == status);

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

            return result;
        }

        public TaskDto? GetById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return null;

            var result = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt
            };

            return result;
        }

        public TaskDto Create(CreateTaskDto dto)
        {
            var task = new Models.TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
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

            return result;
        }

        public bool Update(int id, UpdateTaskDto dto)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;

            _context.SaveChanges();

            return true;

        }

        public bool Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return true;
        }
    }
}
