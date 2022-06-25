using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Models
{
    class Mesto
    {
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public Mesto()
        {

        }

        public Mesto(string naziv, string postanskiBroj)
        {
            Naziv = naziv;
            PostanskiBroj = postanskiBroj;
        }
    }
}
