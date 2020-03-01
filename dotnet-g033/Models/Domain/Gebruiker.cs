using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Gebruiker : IdentityUser<Guid>
    {

        #region Properties
        public long IdNumber { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public StatusType Status { get; private set; }
        public GebruikerType Type { get; set; }
        public ICollection<SessieGebruiker> SessiesIngeschreven { get; set; }
        #endregion

        #region Constructors
        public Gebruiker()
        {
            this.SessiesIngeschreven = new List<SessieGebruiker>();
        }

        public Gebruiker(string username, string voornaam, string achternaam, string email, StatusType status, GebruikerType type)
        {
            this.UserName = username;
            this.NormalizedUserName = username;
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Email = email;
            this.NormalizedEmail = email;
            this.Status = status;
            this.Type = type;
            this.SessiesIngeschreven = new List<SessieGebruiker>();
        }
        #endregion

        #region Methods
        public void SchrijfIn(SessieGebruiker nieuweInschrijving)
        {
            this.SessiesIngeschreven.Add(nieuweInschrijving);
        }

        internal void SchrijfUit(SessieGebruiker nieuweInschrijving)
        {
            this.SessiesIngeschreven.Remove(nieuweInschrijving);
        }
        #endregion

    }
}
