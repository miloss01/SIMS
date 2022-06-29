using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    class StatistikaValuteController
    {
        private NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();
        private RacunRepo racunRepo = new RacunRepo();

        public List<NaplatnaStanica> GetAllNaplatnaStanica()
        {
            return naplatnaStanicaRepo.GetAll();
        }

        public int GetBrojPlacanjaUValutiZaStanicu(string id, Valuta valuta)
        {
            List<Racun> racuni = racunRepo.GetAllRacun();
            int brojPlacanja = 0;

            foreach (Racun racun in racuni)
                if (racun.MestoIzlaska.NaplatnaStanica.ID == id && racun.Valuta == valuta)
                    brojPlacanja += 1;

            return brojPlacanja;
        }

        public double GetSumuPlacanjaUValutiZaStanicu(string id, Valuta valuta)
        {
            List<Racun> racuni = racunRepo.GetAllRacun();
            double suma = 0;

            foreach (Racun racun in racuni)
                if (racun.MestoIzlaska.NaplatnaStanica.ID == id && racun.Valuta == valuta)
                    suma += racun.Cena;

            return suma;
        }
    }
}
