using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using NaplatneRampeSrbije.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    public class PrijavaKvaraController
    {
        private PrijavaKvaraView _window;
        private KvarRepo _kvarRepo;
        public PrijavaKvaraController(PrijavaKvaraView window, KvarRepo kvarRepo)
        {
            _kvarRepo = kvarRepo;
            _window = window;
        }

        internal void PokupiPodatke()
        {
            int masinaIndex = _window.MasinaComboBox.SelectedIndex;
            int vrstaKvaraIndex = _window.MasinaComboBox.SelectedIndex;
            String naplatnoMesto = Globals.ulogovaniRadnik.NaplatnaStanica.ID;
            String opis = _window.OpisTextBox.Text;
            String kvarID = _kvarRepo.getLargestID();
            Kvar kvar = new Kvar(kvarID,(Oprema)masinaIndex,opis,(VrstaKvara)vrstaKvaraIndex,naplatnoMesto);
            _kvarRepo.SaveKvar(kvar);
        }
    }
}
