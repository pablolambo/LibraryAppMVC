using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteczka.Models
{
    public class Ksiazka
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Tytul { get; set; }

        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Display(Name = "Ilość stron")]
        [Range(1, 10000, ErrorMessage = "Książka musi miec przynajmniej 1 stronę")]
        public int IloscStron { get; set; }

        public Ksiazka()
        {
        }

        public Ksiazka(int id, string tytul, string autor, int iloscStron)
        {
            this.ID = id;
            this.Tytul = tytul;
            this.Autor = autor;
            this.IloscStron = iloscStron;
        }
    }
}
