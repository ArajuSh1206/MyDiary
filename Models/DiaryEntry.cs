using System.ComponentModel.DataAnnotations;
namespace MYDIARY.Models
{
    public class DiaryEntry
    {
        //[Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required" )]
        //[StringLength( 100, MinimumLength = 3,
            //ErrorMessage = "Title must be between 3 and 100 characters!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Content is required")]
        //[StringLength( 1500, MinimumLength = 20,
            //ErrorMessage = "Content must be between 20 and 1500 characters!")]
        public string Content { get; set; } = string.Empty;
        [Required(ErrorMessage = "Date is required")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

    }

}