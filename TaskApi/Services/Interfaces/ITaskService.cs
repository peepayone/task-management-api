using TaskApi.DTOs;

namespace TaskApi.Services.Interfaces
{
    public interface ITaskService
    {
        List<TaskDto> GetAll(string? status);
        TaskDto? GetById(int id);
        TaskDto Create(CreateTaskDto dto);
        bool Update(int id, UpdateTaskDto dto);
        bool Delete(int id);
    }
}
