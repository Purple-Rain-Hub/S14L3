using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace S14L3.Models
{
    public class SaleViewModel
    {
        public string? SalaSelezionata { get; set; }
        [Display(Name = "Seleziona la sala")]
        public List<SelectListItem> Sale { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "SUD", Text = "Sala Sud" },
            new SelectListItem { Value = "EST", Text = "Sala Est" },
            new SelectListItem { Value = "NORD", Text = "Sala Nord" },
        };

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        public string? Nome { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il cognome è obbligatorio!")]
        public string? Cognome { get; set; }
        [Display(Name = "Biglietto Ridotto (bambini fino a 10 anni)")]
        public bool Tipo { get; set; }

        public bool Error {  get; set; }

        public List<Utente>? SalaSud { get; set; }
        public List<Utente>? SalaEst { get; set; }
        public List<Utente>? SalaNord { get; set; }
    }
}
