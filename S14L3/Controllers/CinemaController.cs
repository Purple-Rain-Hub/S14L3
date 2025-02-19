using Microsoft.AspNetCore.Mvc;
using S14L3.Models;

namespace S14L3.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Utente> _SalaSud = new List<Utente>();
        private static List<Utente> _SalaEst = new List<Utente>();
        private static List<Utente> _SalaNord = new List<Utente>();
        private bool error = false;

        public IActionResult Index()
        {
            var model = new SaleViewModel()
            {
                SalaSud = _SalaSud,
                SalaEst = _SalaEst,
                SalaNord = _SalaNord,
                Error = error
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SaleViewModel model)
        {
            var values = ModelState.Values;
            if (ModelState.IsValid) {
                Utente utente = new Utente()
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Cognome = model.Cognome
                };
                error = false;
                switch (model.SalaSelezionata)
                {
                    case "SUD":
                        if (_SalaSud.Count < 2)
                        {
                            _SalaSud.Add(utente);
                        }
                        else
                        {
                            error = true;
                        }
                        break;
                    case "EST":
                        if (_SalaEst.Count < 120)
                        {
                            _SalaEst.Add(utente);
                        }
                        else
                        {
                            error = true;
                        }
                        break;
                    case "NORD":
                        if (_SalaNord.Count < 120)
                        {
                            _SalaNord.Add(utente);
                        }
                        else
                        {
                            error = true;
                        }
                        break;
                    default:
                        Console.WriteLine("errore nello switch delle sale");
                        break;
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
