using System.ComponentModel.DataAnnotations;

namespace S14L3.Models
{
    public class Utente
    {

        public Guid Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        public string? Nome { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio!")]
        public string? Cognome { get; set; }
        public bool Tipo {  get; set; }

    }
}
