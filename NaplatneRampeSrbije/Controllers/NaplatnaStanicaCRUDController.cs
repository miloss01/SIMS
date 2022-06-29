using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    public class NaplatnaStanicaCRUDController
    {
        private NaplatnaStanicaRepo _naplatnaStanicaRepo;
        private AdresaRepo _adresaRepo;
        private MestoRepo _mestoRepo;

        public NaplatnaStanicaCRUDController()
        {
            _naplatnaStanicaRepo = new NaplatnaStanicaRepo();
            _adresaRepo = new AdresaRepo();
            _mestoRepo = new MestoRepo();
        }

        public List<NaplatnaStanicaDTO> PreuzmiNapltneStaniceZaPrikaz()
        {
            List<NaplatnaStanicaDTO> naplatneStaniceDTO = new List<NaplatnaStanicaDTO>();
            List<NaplatnaStanica> naplatneStanice = _naplatnaStanicaRepo.GetAll();
            foreach (NaplatnaStanica naplatnaStanica in naplatneStanice)
            {
                NaplatnaStanicaDTO naplatnaStanicaDTO = new NaplatnaStanicaDTO(naplatnaStanica);
                naplatneStaniceDTO.Add(naplatnaStanicaDTO);
            }

            return naplatneStaniceDTO;
        }

        public void KreirajNaplatnuStanicu(string ulica, string broj, string postanskiBroj)
        {
            ProveraUlica(ulica);
            ProveraBroj(broj);
            ProveraMesta(postanskiBroj);
            Mesto mesto = _mestoRepo.GetMestoByPostanskiBroj(postanskiBroj);
            Adresa adresa = new Adresa(ulica, broj, mesto);
            _adresaRepo.Save(adresa);
            NaplatnaStanica naplatnoMesto = new NaplatnaStanica(adresa);
            _naplatnaStanicaRepo.Save(naplatnoMesto);
        }

        public void IzmeniNaplatnuStanicu(string id, string ulica, string broj, string postanskiBroj)
        {
            ProveraUlica(ulica);
            ProveraIdNaplatneStanice(id);
            ProveraBroj(broj);
            ProveraMesta(postanskiBroj);

            NaplatnaStanica naplatnaStanica = _naplatnaStanicaRepo.Get(id);
            Mesto mesto = _mestoRepo.GetMestoByPostanskiBroj(postanskiBroj);

            Adresa adresa = _adresaRepo.GetAdresaById(naplatnaStanica.Adresa.ID);
            adresa.Ulica = ulica;
            adresa.Broj = broj;
            adresa.Mesto = mesto;
            _adresaRepo.Update(adresa);

            naplatnaStanica.Adresa = adresa;
            _naplatnaStanicaRepo.Update(naplatnaStanica);
        }

        public void IzbrisiNaplatnuStanicu(string id)
        {
            ProveraIdNaplatneStanice(id);
            NaplatnaStanica naplatnaStanica = _naplatnaStanicaRepo.Get(id);
            _naplatnaStanicaRepo.Delete(id);
            _adresaRepo.Delete(naplatnaStanica.Adresa.ID);
        }

        private void ProveraIdNaplatneStanice(string id)
        {
            List<NaplatnaStanica> naplatneStanice = _naplatnaStanicaRepo.GetAll();
            foreach (NaplatnaStanica naplatnaStanica in naplatneStanice)
            {
                if (naplatnaStanica.ID == id)
                {
                    return;
                }
            }
            throw new Exception("Nije pronadjen uneti id naplatne stanice");
        }

        private void ProveraBroj(string broj)
        {
            if (!int.TryParse(broj, out _))
            {
                throw new Exception("Pogresan unos broja!");
            }
        }

        private void ProveraMesta(string postanskiBroj)
        {
            List<Mesto> mesta = _mestoRepo.GetAll();
            foreach (Mesto mesto in mesta)
            {
                if (mesto.PostanskiBroj == postanskiBroj)
                {
                    return;
                }
            }
            throw new Exception("Nije pronadjeno mesto!");
        }

        private void ProveraUlica(string ulica)
        {
            if (ulica.Trim() == "")
            {
                throw new Exception("Morate uneti ulicu!");
            }
        }
    }
}