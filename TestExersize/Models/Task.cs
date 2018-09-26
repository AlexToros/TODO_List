using System.ComponentModel.DataAnnotations;

namespace TestExersize.Models
{
    public class Task
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public bool IsDone { get; set; }
        [Display(Name = "Содержание")]
        [Required(ErrorMessage = "Необходимо ввести текст задачи.")]
        public string Content { get; set; }
    }
}