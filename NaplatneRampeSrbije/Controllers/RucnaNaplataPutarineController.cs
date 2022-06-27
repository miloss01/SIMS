using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    class RucnaNaplataPutarineController
    {
        private readonly NaplatnoMestoRepo _naplatnoMestoRepo;

        public RucnaNaplataPutarineController()
        {
            _naplatnoMestoRepo = new NaplatnoMestoRepo();
        }

        public bool IstaNaplatnaStanica(string naplatnoMestoId)
        {
            NaplatnoMesto naplatnoMestoUlaska = _naplatnoMestoRepo.GetNaplatnoMestoById(naplatnoMestoId);
            NaplatnoMesto naplatnoMestoIzlaska = _naplatnoMestoRepo.GetNaplatnoMestoById(Globals.ulogovaniRadnik.NaplatnoMesto.ID);

            return naplatnoMestoUlaska != null && naplatnoMestoUlaska.NaplatnaStanica.ID != naplatnoMestoIzlaska.NaplatnaStanica.ID;
        }
    }
}
