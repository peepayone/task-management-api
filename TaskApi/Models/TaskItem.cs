using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public string? Description { get; set; }

        public string Status { get; set; } = "Todo";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}