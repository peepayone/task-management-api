using System.ComponentModel.DataAnnotations;
namespace TaskApi.DTOs
{
    // 創造Task
    public class CreateTaskDto
    {
        // Title必填 不得超過100字
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = "";

        // Description不得超過500字
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        // Status必填 不得超過20字
        [Required(ErrorMessage = "Status is required.")]
        [MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        public string Status { get; set; } = "Todo";
    }
}
