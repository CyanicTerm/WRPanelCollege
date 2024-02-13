using System;
using System.ComponentModel.DataAnnotations;

namespace WRPanel.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Subject { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public DateTime Start { get; set; }
        [Display(Name = "Koniec")]
        public DateTime End { get; set; }
    }
}
