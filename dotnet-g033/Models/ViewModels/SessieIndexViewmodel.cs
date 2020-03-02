using dotnet_g033.Models.Domain;
using System.Collections.Generic;

namespace dotnet_g033.Models.ViewModels
{
    public class SessieIndexViewmodel
    {
        public Gebruiker Gebruiker { get; set; }

        public IEnumerable<Sessie> Sessies  { get; set; }
        public SessieIndexViewmodel(Gebruiker gebruiker, IEnumerable<Sessie> sessies) 
        {
            this.Gebruiker = gebruiker;
            this.Sessies = sessies;
        }

    }
}
