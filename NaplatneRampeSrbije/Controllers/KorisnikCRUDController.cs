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
                Radnik r = null;
                switch (radnoMesto)
                {
                    case RadnoMesto.ReferentNaplate:
                        NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, naplatnoMestoRepo.GetNaplatnoMestoById(mestoRadaId), null);
                        break;
                    case RadnoMesto.SefNaplatneStanice:
                        NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, null, naplatnaStanicaRepo.GetNaplatnaStanicaById(mestoRadaId));
                        break;
                    case RadnoMesto.Menadzer:
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, null, null);
                        break;
                    case RadnoMesto.Admininstrator:
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, null, null);
                        break;
                    default:
                        r = new Radnik();
                        break;
                }
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
                Radnik r = null;
                switch (radnoMesto)
                {
                    case RadnoMesto.ReferentNaplate:
                        NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, naplatnoMestoRepo.GetNaplatnoMestoById(mestoRadaId), null);
                        break;
                    case RadnoMesto.SefNaplatneStanice:
                        NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, null, naplatnaStanicaRepo.GetNaplatnaStanicaById(mestoRadaId));
                        break;
                    case RadnoMesto.Menadzer:
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, null, null);
                        break;
                    case RadnoMesto.Admininstrator:
                        r = new Radnik(id, ime, prezime, pol, telefon, radnoMesto, korisnickoIme, lozinka, adresa, null, null);
                        break;
                    default:
                        r = new Radnik();
                        break;
                }
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
