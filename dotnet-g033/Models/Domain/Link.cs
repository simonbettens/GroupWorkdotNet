using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Link : Media
    {
        public Link()
        {

        }
        public Link(String adress, String naam,DateTime tijdToegevoegd, MediaType mediaTye)
        {
            this.Adress = adress;
            this.Naam = naam;
            this.TijdToegevoegd = tijdToegevoegd;
            this.MediaType = mediaTye;
        }
        
        public override string Display()
        {
            return $"<div><a href=\"{Adress}\" target=\"_blank\">{Naam}</a></div>";
        }
    }
}
