using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.ViewModels {
    public class SessieDetailsViewModel
    {

        public Sessie _sessie;
        #region Properties
        public string Naam { get; }
        public int SessieId { get; }
        public DateTime StartDatum { get; }
        public DateTime EindDatum { get; }
        public bool OoitGeopend { get; }
        public int MaxCap { get; }
        public int AantalAanwezigeGebruikers { get; }
        public int AantalIngeschrevenGebruikers { get; }
        public int AantalResterend => MaxCap - AantalIngeschrevenGebruikers;
        public string Lokaal { get; }
        public string Beschrijving { get; }
        public string VerantwoordelijkeNaam { get; }
        public bool StaatOpen { get; }
        public bool HeeftMedia { get; }
        public bool HeeftLinken { get; }
        public bool HeeftVideos { get; }
        public bool HeeftDocumenten { get; }
        public bool HeeftAfbeeldingen { get; }
        public bool HeeftInschrevenGebruikers { get; set; }
        public bool KanNogInschrijven => AantalResterend > 0;

        public IEnumerable<Media> Media { get; }
        public IEnumerable<Media> Linken { get; }
        public IEnumerable<Media> Videos { get; }
        public IEnumerable<Media> Documenten { get; }
        public IEnumerable<Media> Afbeeldingen { get; }
        public IEnumerable<SessieGebruiker> GebruikersIngeschreven { get; set; }
        #endregion

        public SessieDetailsViewModel(Sessie sessie)
        {
            this.Naam = sessie.Naam;
            this.SessieId = sessie.SessieId;
            this.StartDatum = sessie.StartDatum;
            this.EindDatum = sessie.EindDatum;
            this.MaxCap = sessie.MaxCap;
            this.AantalAanwezigeGebruikers = sessie.AantalAanwezigeGebruikers;
            this.AantalIngeschrevenGebruikers = sessie.AantalIngeschrevenGebruikers;
            this.Lokaal = sessie.Lokaal;
            this.Beschrijving = sessie.Beschrijving;
            this.VerantwoordelijkeNaam = sessie.Verantwoordelijke.Voornaam + " " + sessie.Verantwoordelijke.Achternaam;
            this.StaatOpen = sessie.StaatOpen;
            this._sessie = sessie;
            this.Media = sessie.Media;
            this.HeeftMedia = sessie.Media.Any();

            Linken = Media.Where(m => m.MediaType == MediaType.Link).ToList();
            Videos = Media.Where(m => (m.MediaType == MediaType.Video || m.MediaType == MediaType.YoutubeVideo)).ToList();
            Documenten = Media.Where(m => (m.MediaType == MediaType.Excel ||
                        m.MediaType == MediaType.Pdf ||
                        m.MediaType == MediaType.Powerpoint ||
                        m.MediaType == MediaType.Word ||
                        m.MediaType == MediaType.Zip ||
                        m.MediaType == MediaType.AnderDocument)).OrderBy(m => m.MediaType).ToList();
            Afbeeldingen = Media.Where(m => m.MediaType == MediaType.Afbeelding).ToList();
            HeeftLinken = Linken.Any();
            HeeftVideos = Videos.Any();
            HeeftDocumenten = Documenten.Any();
            HeeftAfbeeldingen = Afbeeldingen.Any();

            this.GebruikersIngeschreven = sessie.GebruikersIngeschreven.OrderBy(gi => gi.AanwezigBevestiged).ThenBy(gi => gi.Voornaam).ThenBy(gi => gi.Achternaam);
            this.HeeftInschrevenGebruikers = GebruikersIngeschreven.Any();
        }


    }
}
