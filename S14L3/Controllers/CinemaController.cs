using Microsoft.AspNetCore.Mvc;
using S14L3.Models;

namespace S14L3.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Utente> _SalaSud = new List<Utente>();
        private static List<Utente> _SalaEst = new List<Utente>();
        private static List<Utente> _SalaNord = new List<Utente>();
        private static List<Utente> _SalaSelezionata = new List<Utente>();

        public IActionResult Index()
        {
            var model = new SaleViewModel()
            {
                SalaSud = _SalaSud,
                SalaEst = _SalaEst,
                SalaNord = _SalaNord
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
                    Cognome = model.Cognome,
                    Tipo = model.Tipo
                };
                switch (model.SalaSelezionata)
                {
                    case "SUD":
                        if (_SalaSud.Count < 120)
                        {
                            _SalaSud.Add(utente);
                        }
                        else
                        {
                            TempData["error"] = "Sala Piena! Selezionare un'altra sala";
                        }
                        break;
                    case "EST":
                        if (_SalaEst.Count < 120)
                        {
                            _SalaEst.Add(utente);
                        }
                        else
                        {
                            TempData["error"] = "Sala Piena! Selezionare un'altra sala";
                        }
                        break;
                    case "NORD":
                        if (_SalaNord.Count < 120)
                        {
                            _SalaNord.Add(utente);
                        }
                        else
                        {
                            TempData["error"] = "Sala Piena! Selezionare un'altra sala";
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
        [HttpGet("Cinema/Details/Sala{id}")]
        public IActionResult Details(string id)
        {
            if ( id == "SUD")
            {
                _SalaSelezionata = _SalaSud;
            }
            else if (id == "EST")
            {
                _SalaSelezionata = _SalaEst;
            }
            else if (id == "NORD")
            {
                _SalaSelezionata = _SalaNord;
            }
            var model = new SalaSelezionataViewModel()
            {
                SalaSelezionata = _SalaSelezionata
            };
            return View(model);
        }

        [HttpGet("Cinema/Edit/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var selectedUtente = _SalaSelezionata.FirstOrDefault(u => u.Id == id);

            var editUtente = new Utente()
            {
                Id = selectedUtente!.Id,
                Nome = selectedUtente.Nome,
                Cognome = selectedUtente.Cognome,
                Tipo = selectedUtente.Tipo
            };

            return View(editUtente);
        }

        [HttpPost]
        public IActionResult SaveEdit(Guid id, Utente editUtente)
        {
            var selectedUtente = _SalaSelezionata.FirstOrDefault(u=> u.Id== id);
            selectedUtente!.Nome = editUtente.Nome;
            selectedUtente.Cognome = editUtente.Cognome;
            selectedUtente.Tipo = editUtente.Tipo;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var selectedUtente = _SalaSelezionata.FirstOrDefault(u => u.Id == id);
            _SalaSelezionata.Remove(selectedUtente!);

            return RedirectToAction("Index");
        }
    }
}
