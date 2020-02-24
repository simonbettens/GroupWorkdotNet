using System.Collections.Generic;
using System.Linq;

namespace dotnet_g033.Models.Domain
{
    public class Media
    {
        public int MediaId { get; set; }
        public int SessieId { get; set; }
        public IList<Video> Videos { get; set; }
        public IList<Link> Linken { get; set; }
        public IList<Document> Documenten { get; set; }
        public IList<Afbeelding> Afbeeldingen { get; set; }
        public Media()
        {
            Videos = new List<Video>();
            Linken = new List<Link>();
            Documenten = new List<Document>();
            Afbeeldingen = new List<Afbeelding>();
        }
        public Media(IEnumerable<Video> videos, IEnumerable<Link> linken, IEnumerable<Document> documenten, IEnumerable<Afbeelding> afbeeldingen)
        {
            Videos = new List<Video>(videos);
            Linken = new List<Link>(linken);
            Documenten = new List<Document>(documenten);
            Afbeeldingen = new List<Afbeelding>(afbeeldingen);
        }
        public string DisplayAlleMedia()
        {
            string uitvoer = "";
            if (Videos.Any())
            {
                uitvoer += $"<h4>Video's:</h4><div>";
                foreach (var video in Videos)
                {
                    uitvoer += $"{video.Display()}<br/>";
                }
                uitvoer += "</div>";
            }
            if (Afbeeldingen.Any())
            {
                uitvoer += $"<h4>Afbeeldingen:</h4><div class=\"row\">";
                foreach (var afbeelding in Afbeeldingen)
                {
                    uitvoer += $"<div class=\"col-md-4\"><div class=\"thumbnail\">{afbeelding.Display()}</div></div>";
                }
                uitvoer += "</div>";
            }
            if (Documenten.Any())
            {
                Documenten.OrderBy(d=>d.MediaType);
                uitvoer += $"<h4>Documenten:</h4><div><table class=\"table\">";
                uitvoer += $"<tr>" +
                    $"<th></th>" +
                    $"<th>Naam</th>" +
                    $"<th>Datum Toegevoegd</th>" +
                    $"</tr>";
                foreach (var document in Documenten)
                {
                    uitvoer += document.Display();
                }
                uitvoer += "</table></div>";
            }
            if (Linken.Any())
            {
                uitvoer += $"<h4>Links:</h4>";
                foreach (var link in Linken)
                {
                    uitvoer += link.Display();
                }
            }
            if (uitvoer != "") {
                uitvoer = "<li class=\"list-group-item\"><div>"+uitvoer+"</div></li>";
            }
            return uitvoer;
        }
        public void VoegVideoToe(Video video)
        {
            Videos.Add(video);
        }
        public void VoegAfbeeldingToe(Afbeelding afbeelding)
        {
            Afbeeldingen.Add(afbeelding);
        }
        public void VoegLinkToe(Link link)
        {
            Linken.Add(link);
        }
        public void VoegDocumentToe(Document document)
        {
            Documenten.Add(document);
        }

    }
}
