using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnet_g033.Models.Domain
{
    public class Sessie {

        public string Naam { get; private set; }
        public int SessieId { get; private set; }
        public DateTime StartDatum { get; private set; }
        public DateTime EindDatum { get; private set; }
        public bool OoitGeopend { get; private set; }
        public int MaxCap { get; private set; }
        public int AantalAanwezigeGebruikers { get; private set; }
        public string Lokaal { get; private set; }
        //public Media Media { get; set; }
        public ICollection<Media> Media { get; set; }
        public string Beschrijving {get; set;}
        public Verantwoordelijke Verantwoordelijke { get; set; }
        public bool StaatOpen { get; set; }
        public Sessie()
        {

        }

        public Sessie(string naam, DateTime start, DateTime eind, bool ooitGeopend, int maxCap, int aantalAanwezigeGebruikers, string lokaal, Verantwoordelijke verantwoordelijke, string beschrijving = "", bool staatOpen = false)
        {
            this.Naam = naam;
            this.StartDatum = start;
            this.EindDatum = eind;
            this.OoitGeopend = ooitGeopend;
            this.MaxCap = maxCap;
            this.AantalAanwezigeGebruikers = aantalAanwezigeGebruikers;
            this.Lokaal = lokaal;
            this.Media = new List<Media>();
            this.Beschrijving = beschrijving;
            this.Verantwoordelijke = verantwoordelijke;
            this.StaatOpen = staatOpen;
        }
        public string DisplayAlleMedia()
        {
            List<Media> linken = Media.Where(m => m.MediaType == MediaType.Link).ToList();
            List<Media> videos = Media.Where(m => (m.MediaType == MediaType.Video||m.MediaType == MediaType.YoutubeVideo)).ToList();
            List<Media> documenten = Media.Where(m => (m.MediaType == MediaType.Excel||
                        m.MediaType==MediaType.Pdf||
                        m.MediaType==MediaType.Powerpoint||
                        m.MediaType==MediaType.Word||
                        m.MediaType==MediaType.Zip||
                        m.MediaType==MediaType.AnderDocument)).ToList();
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
        public void VoegMediaToe(Media media)
        {
            Media.Add(media);
        }
    }
}
