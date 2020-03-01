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
        public bool OoitGeopend { get; private set; }
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
        public Sessie(string naam, DateTime start, DateTime eind, bool ooitGeopend, int maxCap, string lokaal, Verantwoordelijke verantwoordelijke, string beschrijving = "", bool staatOpen = false)
        {
            this.Naam = naam;
            this.StartDatum = start;
            this.EindDatum = eind;
            this.OoitGeopend = ooitGeopend;
            this.MaxCap = maxCap;
            this.Lokaal = lokaal;
            this.Media = new List<Media>();
            this.Beschrijving = beschrijving;
            this.Verantwoordelijke = verantwoordelijke;
            this.StaatOpen = staatOpen;
            this.GebruikersIngeschreven = new List<SessieGebruiker>();
        }
        #endregion

        #region DisplayMedia
        //html code voor de media te tonen
        public string DisplayAlleMedia()
        {
            List<Media> linken = Media.Where(m => m.MediaType == MediaType.Link).ToList();
            List<Media> videos = Media.Where(m => (m.MediaType == MediaType.Video || m.MediaType == MediaType.YoutubeVideo)).ToList();
            List<Media> documenten = Media.Where(m => (m.MediaType == MediaType.Excel ||
                        m.MediaType == MediaType.Pdf ||
                        m.MediaType == MediaType.Powerpoint ||
                        m.MediaType == MediaType.Word ||
                        m.MediaType == MediaType.Zip ||
                        m.MediaType == MediaType.AnderDocument)).ToList();
            List<Media> afbeeldingen = Media.Where(m => m.MediaType == MediaType.Afbeelding).ToList();
            string uitvoer = "";
            if (videos.Any())
            {
                uitvoer += $"<h4>Video's:</h4><div>";
                foreach (var video in videos)
                {
                    uitvoer += $"{video.Display()}<br/>";
                }
                uitvoer += "</div>";
            }
            if (afbeeldingen.Any())
            {
                uitvoer += $"<h4>Afbeeldingen:</h4><div class=\"row\">";
                foreach (var afbeelding in afbeeldingen)
                {
                    uitvoer += $"<div class=\"col-md-4\"><div class=\"thumbnail\">{afbeelding.Display()}</div></div>";
                }
                uitvoer += "</div>";
            }
            if (documenten.Any())
            {
                documenten.OrderBy(d => d.MediaType);
                uitvoer += $"<h4>Documenten:</h4><div><table class=\"table\">";
                uitvoer += $"<tr>" +
                    $"<th></th>" +
                    $"<th>Naam</th>" +
                    $"<th>Datum Toegevoegd</th>" +
                    $"</tr>";
                foreach (var document in documenten)
                {
                    uitvoer += document.Display();
                }
                uitvoer += "</table></div>";
            }
            if (linken.Any())
            {
                uitvoer += $"<h4>Links:</h4>";
                foreach (var link in linken)
                {
                    uitvoer += link.Display();
                }
            }
            if (uitvoer != "")
            {
                uitvoer = "<li class=\"list-group-item\"><div>" + uitvoer + "</div></li>";
            }
            return uitvoer;
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
        #endregion

    }
}
