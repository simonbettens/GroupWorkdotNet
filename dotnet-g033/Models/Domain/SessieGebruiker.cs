using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain {
    public class SessieGebruiker {
        public Sessie Sessie { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public long GebruikerId { get; set; }
        public int SessieId { get; set; }
        private bool Aanwezig { get; set; }

        public SessieGebruiker(Sessie sessie, Gebruiker gebruiker, int sessieId, long gebruikerId) {
            this.Sessie = sessie;
            this.Gebruiker = gebruiker;
            this.GebruikerId = gebruikerId;
            this.SessieId = sessieId;
            this.Aanwezig = false;
        }

        
    }
}
