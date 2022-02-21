using System.ComponentModel.DataAnnotations;

namespace WRPanel.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
