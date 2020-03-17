using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain {
    public class SessieGebruiker {

        #region Properties
        public Guid GebruikerId { get; set; }
        public int SessieId { get; set; }
        public long IdNumber { get; set; }
        public string UserName { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool Aanwezig { get; set; }
        public bool AanwezigBevestiged { get; set; }
        #endregion

        #region Relatie properties
        public Sessie Sessie { get; set; }
        public Gebruiker Gebruiker { get; set; }
        #endregion

       

        #region Constructors
        public SessieGebruiker()
        {

        }
        public SessieGebruiker(Sessie sessie, Gebruiker gebruiker)
        {
            this.Sessie = sessie;
            this.Gebruiker = gebruiker;
            this.IdNumber = gebruiker.IdNumber;
            this.Voornaam = gebruiker.Voornaam;
            this.Achternaam = gebruiker.Achternaam;
            this.UserName = gebruiker.UserName;
            this.GebruikerId = gebruiker.Id;
            this.SessieId = sessie.SessieId;
            this.Aanwezig = false;
            this.AanwezigBevestiged = false;
        }
        #endregion
    }
}
