using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain {
    public class Verantwoordelijke : Gebruiker {
        public ICollection<Sessie> BeheerdeSessies { get; set; }

        public Verantwoordelijke(long idNumber, string username, string voornaam, string achternaam, string email, StatusType status, GebruikerType type) 
            : base(idNumber, username, voornaam, achternaam, email, status, type)
        {
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
