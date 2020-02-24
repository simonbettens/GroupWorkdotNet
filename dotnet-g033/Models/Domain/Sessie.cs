using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnet_g033.Models.Domain
{
    public class Sessie {

        public String Naam { get; private set; }
        public int SessieId { get; private set; }
        public DateTime StartDatum { get; private set; }
        public DateTime EindDatum { get; private set; }
        public bool Geopend { get; private set; }
        public int MaxCap { get; private set; }
        public int AantalAanwezigeGebruikers { get; private set; }
        public string Lokaal { get; private set; }
        public Media Media { get; set; }
        public String Beschrijving {get; set;}

        public Sessie()
        {

        }

        public Sessie(String naam, DateTime start, DateTime eind, bool geopend, int maxCap, int aantalAanwezigeGebruikers, String lokaal, String beschrijving = "")
        {
            this.Naam = naam;
            this.StartDatum = start;
            this.EindDatum = eind;
            this.Geopend = geopend;
            this.MaxCap = maxCap;
            this.AantalAanwezigeGebruikers = aantalAanwezigeGebruikers;
            this.Lokaal = lokaal;
            this.Media = new Media();
            this.Beschrijving = beschrijving;
        }
    }
}
