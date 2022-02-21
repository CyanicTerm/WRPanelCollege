using System.ComponentModel.DataAnnotations;

namespace WRPanel.Models
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numer przechowalni jest wymagany"), Display(Name = "Przechowalnia nr")]
        public int StorageNum { get; set; }

        [Required(ErrorMessage = "Numer rejestracyjny jest wymagany"), Display(Name = "Numer rejestracyjny"),]
        public string PlateNum { get; set; }

        [Required(ErrorMessage = "Opona jest wymagana"), Display(Name = "Opona")]
        public string Tire { get; set; }

        [Required(ErrorMessage = "Ilość sztuk jest wymagana"), Display(Name = "Ilość sztuk")]
        public int TireNum { get; set; }

        [Display(Name = "Felga")]
        public string? Rim { get; set; }

        [Display(Name = "Ilość felg")]
        public int? RimNum { get; set; }

        [Display(Name = "Uwagi")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Klient jest wymagany")]
        [Display(Name = "Numer klienta")]
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
