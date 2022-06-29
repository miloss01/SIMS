using NaplatneRampeSrbije.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije
{
    public class NaplatnaStanicaDTO
    {
        private readonly int id;

        public NaplatnaStanicaDTO(string id, string ulica, string broj, string mesto, string postanskiBroj)
        {
            ID = id;
            Ulica = ulica;
            Broj = broj;
            Mesto = mesto;
            PostanskiBroj = postanskiBroj;
        }

        public NaplatnaStanicaDTO(NaplatnaStanica naplatnaStanica)
        {
            ID = naplatnaStanica.ID;
            Ulica = naplatnaStanica.Adresa.Ulica;
            Broj = naplatnaStanica.Adresa.Broj;
            Mesto = naplatnaStanica.Adresa.Mesto.Naziv;
            PostanskiBroj = naplatnaStanica.Adresa.Mesto.PostanskiBroj;
        }

        public string ID { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Mesto { get; set; }
        public string PostanskiBroj { get; set; }
    }
}