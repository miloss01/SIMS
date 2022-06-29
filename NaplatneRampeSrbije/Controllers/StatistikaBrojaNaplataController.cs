using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    internal class StatistikaBrojaNaplataController
    {
        public int PreuzmiBrojNaplata(string izabraniDatum)
        {
            ProveraValidnostiDatuma(izabraniDatum);
            DateTime izabraniDatumDate = Convert.ToDateTime(izabraniDatum).Date;

            RacunRepo racunRepo = new RacunRepo();
            List<Racun> racuni = racunRepo.GetAllRacun();

            int brojac_naplata = 0;
            foreach (Racun racun in racuni)
            {
                DateTime datumGenerisanjaRacuna = racun.VremeIzlaska.Date;
                if (datumGenerisanjaRacuna == izabraniDatumDate)
                {
                    brojac_naplata++;
                }
            }

            return brojac_naplata;
        }

        public double PreuzmiZaradu(string izabraniDatum)
        {
            ProveraValidnostiDatuma(izabraniDatum);
            DateTime izabraniDatumDate = Convert.ToDateTime(izabraniDatum).Date;

            RacunRepo racunRepo = new RacunRepo();
            List<Racun> racuni = racunRepo.GetAllRacun();

            double suma = 0;
            foreach (Racun racun in racuni)
            {
                DateTime datumGenerisanjaRacuna = racun.VremeIzlaska.Date;
                if (datumGenerisanjaRacuna == izabraniDatumDate)
                {
                    suma = suma + racun.Cena;
                }
            }

            return suma;
        }

        private void ProveraValidnostiDatuma(string datum)
        {
            if (!DateTime.TryParse(datum, out DateTime _))
            {
                throw new Exception("Los unos datuma!");
            }
        }
    }
}