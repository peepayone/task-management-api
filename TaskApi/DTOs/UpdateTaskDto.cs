using System.ComponentModel.DataAnnotations;
namespace TaskApi.DTOs
{
    public class UpdateTaskDto
    {
        [Required]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string Status { get; set; } = "";
    }
}
