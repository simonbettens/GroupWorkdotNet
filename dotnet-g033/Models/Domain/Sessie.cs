using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Sessie
    {
        public String Naam { get; private set; }
        public long Id { get; private set; }
        public DateTime StartDatum { get; private set; }
        public DateTime EindDatum { get; private set; }
        public bool Geopend { get; private set; }
        public int MaxCap { get; private set; }
        public int AantalAanwezigeGebruikers { get; private set; }

        public Sessie()
        {

        }
        public Sessie(String naam, long id,DateTime? start,DateTime? eind,bool geopend,int maxCap,int aantalAanwezigeGebruikers)
        {
            this.Naam = naam;
            this.Id = id;
            this.StartDatum = start.GetValueOrDefault();
            this.EindDatum = eind.GetValueOrDefault();
            this.Geopend = geopend;
            this.MaxCap = maxCap;
            this.AantalAanwezigeGebruikers = aantalAanwezigeGebruikers;
        }
    }
}
