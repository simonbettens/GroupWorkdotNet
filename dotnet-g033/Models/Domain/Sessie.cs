using System;
using System.Collections.Generic;
using System.Linq;


namespace dotnet_g033.Models.Domain
{
    public class Sessie
    {

        #region Sessie Properties
        public string Naam { get; private set; }
        public int SessieId { get; private set; }
        public DateTime StartDatum { get; private set; }
        public DateTime EindDatum { get; private set; }
        public bool Gesloten { get; private set; }
        public int MaxCap { get; private set; }
        public int AantalAanwezigeGebruikers => AantalIngeschrevenGebruikers==0?0:this.GebruikersIngeschreven.Where(g => g.Aanwezig==true).ToList().Count;
        public int AantalIngeschrevenGebruikers => this.GebruikersIngeschreven.Count;
        public string Lokaal { get; private set; }
        public string Beschrijving { get; set; }
        public Verantwoordelijke Verantwoordelijke { get; set; }
        public bool StaatOpen { get; set; }
        #endregion

        #region Collections
        //lijst media items
        public ICollection<Media> Media { get; set; }
        //lijst van sessiegebruikers objecten die ingeschreven zijn bij een sessie
        public ICollection<SessieGebruiker> GebruikersIngeschreven { get; set; }
        #endregion

        #region Constructors
        //voor databank
        public Sessie()
        {
            Media = new List<Media>();
            GebruikersIngeschreven = new List<SessieGebruiker>();
        }
        //volledige constructor
        public Sessie(string naam, DateTime start, DateTime eind, bool gesloten, int maxCap, string lokaal, Verantwoordelijke verantwoordelijke, string beschrijving = "", bool staatOpen = false)
        {
            this.Naam = naam;
            this.StartDatum = start;
            this.EindDatum = eind;
            this.Gesloten = gesloten;
            this.MaxCap = maxCap;
            this.Lokaal = lokaal;
            this.Media = new List<Media>();
            this.Beschrijving = beschrijving;
            this.Verantwoordelijke = verantwoordelijke;
            this.StaatOpen = staatOpen;
            this.GebruikersIngeschreven = new List<SessieGebruiker>();
        }
        #endregion

        #region Methods
        //voegt een media object toe aan de lijst (gebruikt voor het toevoegen van media bij testen en dummydata)
        public void VoegMediaToe(Media media)
        {
            Media.Add(media);
        }
        //krijgt een SessieGebruiker object binnen en voegt het toe aan de lijst
        public void SchrijfGebruikerIn(SessieGebruiker nieuweInschrijving,Gebruiker gebruiker)
        {
            GebruikersIngeschreven.Add(nieuweInschrijving);
            gebruiker.SchrijfIn(nieuweInschrijving);
        }
        public SessieGebruiker GeefSessieGebruiker(Gebruiker gebruiker) {
            return GebruikersIngeschreven.FirstOrDefault(gs => gs.GebruikerId == gebruiker.Id);
        }
        public void SchrijfGebruikerUit(SessieGebruiker nieuweInschrijving, Gebruiker gebruiker)
        {
            GebruikersIngeschreven.Remove(nieuweInschrijving);
            gebruiker.SchrijfUit(nieuweInschrijving);
        }
        public bool GebruikerIsIngeschreven(Gebruiker gebruiker) {
            return GebruikersIngeschreven.Any(gs => gs.GebruikerId == gebruiker.Id);
        }

        public void StelGebruikerAanwezig(SessieGebruiker aanmelding) {
            aanmelding.Aanwezig = true;
        }

        public void ZetOpen()
        {
            this.StaatOpen = true;
        }

        public void Sluit()
        {
            this.StaatOpen = false;
        }
        #endregion

    }
}
