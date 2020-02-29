using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain {
    public class Verantwoordelijke : Gebruiker {
        public ICollection<Sessie> BeheerdeSessies;

        public Verantwoordelijke(string username, string voornaam, string achternaam, string email, bool actief) :base(username, voornaam, achternaam, email, actief) {
            BeheerdeSessies = new List<Sessie>();
        }

        public Verantwoordelijke() {
            BeheerdeSessies = new List<Sessie>();
        }

        public void voegSessieToe(Sessie sessie) {
            BeheerdeSessies.Add(sessie);
        }
    }
}
