using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Biblioteczka.Models
{
    public class KontekstKsiazek
    {
        private List<Ksiazka> kolekcjaKsiazek;
        private static KontekstKsiazek instancja;

        public static KontekstKsiazek Instancja
        {
            get
            {
                if (instancja == null)
                    instancja = new KontekstKsiazek();
                return instancja;
            }
        }

        private KontekstKsiazek()
        {
            kolekcjaKsiazek = new List<Ksiazka>();
            ZaladujDane();
        }

        private void ZaladujDane()
        {
            this.Dodaj("Pan Tadeusz", "Adam Mickiewicz", 800);
            this.Dodaj("Agile. Programowanie zwinne", "Robert C. Martin", 700);
            this.Dodaj("Czysty kod", "Robert C. Martin", 400);
        }

        public void Dodaj(string tytul, string autor, int iloscStron)
        {
            int id = this.kolekcjaKsiazek.Count + 1;

            this.kolekcjaKsiazek.Add(new Ksiazka(id, tytul, autor, iloscStron));
        }

        public Ksiazka Pobierz(int id)
        {
            var ksiazka = (from k in this.kolekcjaKsiazek where k.ID == id select k).FirstOrDefault();
            return ksiazka as Ksiazka;
        }

        public List<Ksiazka> PobierzWszystkie()
        {
            return this.kolekcjaKsiazek;
        }

        public void Usun(int id)
        {
            Ksiazka ks = this.Pobierz(id);
            if (ks != null)
                this.kolekcjaKsiazek.Remove(ks);
        }

        public void Edytuj(int id, string tytul, string autor, int iloscStron)
        {
            Ksiazka ks = Pobierz(id);
            ks.Tytul = tytul;
            ks.Autor = autor;
            ks.IloscStron = iloscStron;
        }
    }
}