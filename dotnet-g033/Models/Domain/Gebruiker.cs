using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Gebruiker : IdentityUser<Guid>
    {
        public long IdNumber { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool Actief { get; private set; }
        public IEnumerable<Sessie> Sessies { get; set; }

        public Gebruiker()
        {

        }

        public Gebruiker(string username, string voornaam, string achternaam, string email, bool actief )
        {
            this.UserName = username;
            this.NormalizedUserName = username;
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Email = email;
            this.NormalizedEmail = email;
            this.Actief = actief;
        }

        //TODO ophalen actieve users

    }
}
