using System;
using System.Collections.Generic;
using System.Linq;
using KundeApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace KundeApp1.Controllers
{

    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {

        private readonly KundeDB _kundeDB;

        public KundeController(KundeDB kundeDB)
        {
            _kundeDB = kundeDB;
        }

        public bool Lagre(Kunde innKunde)
        {
            try
            {
                _kundeDB.Kunder.Add(innKunde);
                _kundeDB.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
            
        }

        public List<Kunde> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = _kundeDB.Kunder.ToList();
                return alleKundene;
            }

            catch
            {
                return null;
            }
        }

        public bool Slett(int id)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(id);
                _kundeDB.Kunder.Remove(enKunde);
                _kundeDB.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public Kunde HentEn(int id)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(id);
                return enKunde;
            }

            catch
            {
                return null;
            }
        }

        public bool Endre(Kunde endreKunde)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(endreKunde.id);
                enKunde.navn = endreKunde.navn;
                enKunde.adresse = endreKunde.adresse;
                _kundeDB.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

    }
}

