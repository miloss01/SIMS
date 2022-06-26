using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NaplatneRampeSrbije.Controllers
{
    class KorisnikCRUDController
    {
        private readonly RadnikRepo _radnikRepo;
        private readonly AdresaRepo _adresaRepo;

        public KorisnikCRUDController()
        {
            _radnikRepo = new RadnikRepo();
            _adresaRepo = new AdresaRepo();
        }

        public bool NapraviRadnika(string id, string ime, string prezime, Pol pol, string telefon, RadnoMesto radnoMesto, string korisnickoIme, string lozinka, string adresaId, string mestoRadaId)
        {
            try
            {
                Adresa adresa = _adresaRepo.GetAdresaById(adresaId);
                if (string.IsNullOrEmpty(id))
                {
                    return false;
                }
                Radnik r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, mestoRadaId);
                bool uspesno = _radnikRepo.Save(r);
                return uspesno;
            }
            catch
            {
                return false;
            }
        }

        public bool IzmijeniRadnika(string stariId, string id, string ime, string prezime, Pol pol, string telefon, RadnoMesto radnoMesto, string korisnickoIme, string lozinka, string adresaId, string mestoRadaId)
        {
            try
            {
                Adresa adresa = _adresaRepo.GetAdresaById(adresaId);
                if (string.IsNullOrEmpty(id))
                {
                    return false;
                }
                Radnik r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, mestoRadaId);
                bool uspesno = _radnikRepo.Izmijeni(stariId, r);
                return uspesno;
            }
            catch
            {
                return false;
            }
        }

        public void UkloniRadnika(string id)
        {
            _radnikRepo.Ukloni(id);
        }

        public List<Radnik> VratiSveRadnike()
        {
            return _radnikRepo.GetAll();
        }
    }
}
