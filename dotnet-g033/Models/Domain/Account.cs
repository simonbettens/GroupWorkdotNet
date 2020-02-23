using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Account
    {
        public long Id { get; set; }
        public string Username { get; private set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool Actief { get; private set; }

        public Account()
        {

        }

        public Account(string username, string voornaam, string achternaam, bool actief )
        {
            this.Username = username;
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Actief = actief;
        }

        //TODO ophalen actieve users

    }
}
