using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteczka.Models;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Biblioteczka.Controllers
{
    public class Biblioteczka : Controller
    {
        public ActionResult Index()
        {
            return View(KontekstKsiazek.Instancja.PobierzWszystkie());
        }

        // GET: Biblioteczka/Details/5
        public ActionResult Details(int id)
        {
            Ksiazka ks = KontekstKsiazek.Instancja.Pobierz(id);
            return View(ks);
        }

        // GET: Biblioteczka/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ksiazka ksiazka)
        {
            // Rozbudowana walidacja
            // ModelState.IsValid indicates if it was possible to bind the incoming values from the request to the model correctly
            // and whether any explicitly specified validation rules were broken during the model binding process.
            if (ModelState.IsValid)
            {
                KontekstKsiazek.Instancja.Dodaj(ksiazka.Tytul, ksiazka.Autor, ksiazka.IloscStron);
                return RedirectToAction("Index");
            }

            return View(ksiazka);
        }

        // GET: Biblioteczka/Edit/5
        public ActionResult Edit(int id)
        {
            var ksiazka = KontekstKsiazek.Instancja.Pobierz(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            return View(ksiazka);
        }

        // POST: Biblioteczka/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ksiazka ksiazka, IFormCollection collection)
        {
            // Rozbudowana walidacja
            if (ModelState.IsValid)
            {
                KontekstKsiazek.Instancja.Edytuj(id, ksiazka.Tytul, ksiazka.Autor, ksiazka.IloscStron);
                return RedirectToAction(nameof(Index));
            }

            return View(ksiazka);
        }

        // GET: Biblioteczka/Delete/5
        public ActionResult Delete(int id)
        {
            var ksiazka = KontekstKsiazek.Instancja.Pobierz(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            return View(ksiazka);
        }

        // POST: Biblioteczka/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                KontekstKsiazek.Instancja.Usun(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
