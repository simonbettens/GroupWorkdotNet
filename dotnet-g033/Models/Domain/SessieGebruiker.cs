using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain {
    public class SessieGebruiker {
        #region Ids
        public Guid GebruikerId { get; set; }
        public int SessieId { get; set; }
        #endregion

        #region Relatie properties
        public Sessie Sessie { get; set; }
        public Gebruiker Gebruiker { get; set; }
        #endregion

        #region Properties
        public bool Aanwezig { get; set; }
        #endregion

        #region Constructors
        public SessieGebruiker()
        {

        }
        public SessieGebruiker(Sessie sessie, Gebruiker gebruiker)
        {
            this.Sessie = sessie;
            this.Gebruiker = gebruiker;
            this.GebruikerId = gebruiker.Id;
            this.SessieId = sessie.SessieId;
            this.Aanwezig = false;
        }
        #endregion
    }
}
