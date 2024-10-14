using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteczka.Models;

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

        // Paweł Frankowski
        [HttpPost]
        public ActionResult Create(Ksiazka ksiazka)
        {
            // Rozbudowana walidacja
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
