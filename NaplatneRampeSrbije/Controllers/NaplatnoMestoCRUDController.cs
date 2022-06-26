using NaplatneRampeSrbije.Models;
using NaplatneRampeSrbije.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaplatneRampeSrbije.Controllers
{
    class NaplatnoMestoCRUDController
    {
        private NaplatnoMestoRepo naplatnoMestoRepo = new NaplatnoMestoRepo();
        private NaplatnaStanicaRepo naplatnaStanicaRepo = new NaplatnaStanicaRepo();

        public List<NaplatnoMesto> GetAllNaplatnoMesto()
        {
            return naplatnoMestoRepo.GetAllNaplatnoMesto();
        }

        public List<NaplatnaStanica> GetAllNaplatnaStanica()
        {
            return naplatnaStanicaRepo.GetAllNaplatnaStanica();
        }

        public bool SaveNaplatnoMesto(string id, string naplatnaStanicaID, bool elNaplata)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(naplatnaStanicaID))
                return false;

            NaplatnoMesto naplatnoMesto = new NaplatnoMesto(id, naplatnaStanicaRepo.GetNaplatnaStanicaById(naplatnaStanicaID), elNaplata);

            naplatnoMestoRepo.SaveNaplatnoMesto(naplatnoMesto);
            return true;
        }

        public bool EditNaplatnoMesto(string id, string naplatnaStanicaID, bool elNaplata)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(naplatnaStanicaID))
                return false;

            NaplatnoMesto naplatnoMesto = new NaplatnoMesto(id, naplatnaStanicaRepo.GetNaplatnaStanicaById(naplatnaStanicaID), elNaplata);

            naplatnoMestoRepo.EditNaplatnoMesto(naplatnoMesto);
            return true;
        }

        public bool DeleteNaplatnoMesto(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            naplatnoMestoRepo.DeleteNaplatnoMesto(id);
            return true;
        }
    }
}
