using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.ViewModels {
    public class SessieDetailsViewModel {

        private readonly Sessie _sessie;
        #region Properties
        public string Naam { get;  }
        public int SessieId { get;  }
        public DateTime StartDatum { get;  }
        public DateTime EindDatum { get;  }
        public bool OoitGeopend { get;  }
        public int MaxCap { get; }
        public int AantalAanwezigeGebruikers { get; }
        public int AantalIngeschrevenGebruikers { get; }
        public int AantalResterend => MaxCap - AantalIngeschrevenGebruikers;
        public string Lokaal { get;  }
        public string Beschrijving { get;  }
        public string VerantwoordelijkeNaam { get;  }
        public bool StaatOpen { get;  }
        #endregion


        public SessieDetailsViewModel(Sessie sessie) {
            this.Naam = sessie.Naam;
            this.SessieId = sessie.SessieId;
            this.StartDatum = sessie.StartDatum;
            this.EindDatum = sessie.EindDatum;
            this.MaxCap = sessie.MaxCap;
            this.AantalAanwezigeGebruikers = sessie.AantalAanwezigeGebruikers;
            this.AantalIngeschrevenGebruikers = sessie.AantalIngeschrevenGebruikers;
            this.Lokaal = sessie.Lokaal;
            this.Beschrijving = sessie.Beschrijving;
            this.VerantwoordelijkeNaam = sessie.Verantwoordelijke.Voornaam + " "+ sessie.Verantwoordelijke.Achternaam;
            this.StaatOpen = sessie.StaatOpen;
            this._sessie = sessie;
        }
        public String DisplayMedia() {
            return _sessie.DisplayAlleMedia();
        }
        
    }
}
