using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    class RacunController
    {
        private RacunRepo racunRepo = new RacunRepo();
        private CenovnikRepo cenovnikRepo = new CenovnikRepo();
        private DeonicaRepo deonicaRepo = new DeonicaRepo();
        private NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();

        public bool SaveRacun(string racun_id, string vozilo, string cena, string valuta, DateTime vremeIzlaska, string izlazakMestoId, string ulazakMestoId)
        {
            NaplatnoMesto ulazak = naplatnoMestoRepo.GetNaplatnoMestoById(ulazakMestoId);
            NaplatnoMesto izlazak = naplatnoMestoRepo.GetNaplatnoMestoById(izlazakMestoId);

            VrstaVozila vrstaVozila = (VrstaVozila)Enum.Parse(typeof(VrstaVozila), vozilo);
            Valuta val = (Valuta)Enum.Parse(typeof(Valuta), valuta);

            Racun r = new Racun(racun_id, vrstaVozila, double.Parse(cena), val, vremeIzlaska, izlazak, ulazak);

            return racunRepo.SaveRacun(r);
        }

        public double GetCenaZaDeonicuIVozilo(string pocetak_mesto_id, VrstaVozila vozilo)
        {
            Cenovnik cenovnik = cenovnikRepo.GetTrenutniCenovnik();

            NaplatnoMesto ulazak = naplatnoMestoRepo.GetNaplatnoMestoById(pocetak_mesto_id);
            NaplatnoMesto kraj = Globals.ulogovaniRadnik.NaplatnoMesto;

            Deonica deonica = deonicaRepo.GetDeonicaByUlazakIIzlazak(ulazak.NaplatnaStanica.ID, kraj.NaplatnaStanica.ID);

            double cena = 0;

            foreach (StavkaCenovnika stavka in cenovnik.Stavke)
                if (stavka.Deonica.ID == deonica.ID && stavka.VrstaVozila == vozilo)
                {
                    cena = stavka.Cena;
                    break;
                }

            return cena;
        }
    }
}
