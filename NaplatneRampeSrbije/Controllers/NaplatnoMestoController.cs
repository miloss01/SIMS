using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    class NaplatnoMestoController
    {
        private readonly NaplatnoMestoRepo _naplatnoMestoRepo;
        private readonly RacunRepo _racunRepo;

        public NaplatnoMestoController()
        {
            _naplatnoMestoRepo = new NaplatnoMestoRepo();
            _racunRepo = new RacunRepo();
        }

        public bool IstaNaplatnaStanica(string naplatnoMestoId1, string naplatnoMestoId2)
        {
            NaplatnoMesto naplatnoMesto1 = _naplatnoMestoRepo.GetNaplatnoMestoById(naplatnoMestoId1);
            NaplatnoMesto naplatnoMesto2 = _naplatnoMestoRepo.GetNaplatnoMestoById(naplatnoMestoId2);

            return naplatnoMesto1.NaplatnaStanica.ID == naplatnoMesto2.NaplatnaStanica.ID;
        }

        public List<NaplatnoMesto> VratiSveNaplatneStanice()
        {
            return _naplatnoMestoRepo.GetAllNaplatnoMesto();
        }

        public VrstaVozila VratiNajcesceProlazeceVozilo(string naplatnoMestoId)
        {
            VrstaVozila najcesceVozilo = VrstaVozila.None;
            Dictionary<VrstaVozila, int> prolasciVozila = new Dictionary<VrstaVozila, int>
            {
                [najcesceVozilo] = 0
            };
            foreach (Racun racun in _racunRepo.GetAllRacun())
            {
                if (!prolasciVozila.ContainsKey(racun.VrstaVozila))
                {
                    prolasciVozila[racun.VrstaVozila] = 0;
                }

                if (naplatnoMestoId == racun.MestoIzlaska.ID || naplatnoMestoId == racun.MestoUlaska.ID)
                {
                    ++prolasciVozila[racun.VrstaVozila];
                }
            }

            foreach (KeyValuePair<VrstaVozila, int> kvp in prolasciVozila)
            {
                if (kvp.Value > prolasciVozila[najcesceVozilo])
                {
                    najcesceVozilo = kvp.Key;
                }
            }

            return najcesceVozilo;
        }
    }
}
