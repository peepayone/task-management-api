using System.ComponentModel.DataAnnotations;
namespace TaskApi.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string Status { get; set; } = "Todo";
    }
}
