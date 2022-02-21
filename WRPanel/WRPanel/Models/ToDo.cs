using System.ComponentModel.DataAnnotations;

namespace WRPanel.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Zadanie")]
        public string TaskName { get; set; }

        [Display(Name = "Czy jest ważne?")]
        public bool IsImportant { get; set; } = false;

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Czy jest zrobione?")]
        public bool IsDone { get; set; } = false;
    }
}
