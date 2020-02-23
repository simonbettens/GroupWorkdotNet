using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Link 
    {
        public int Id { get; set; }
        public String Adress { get; set; }
        public String Naam { get; set; }
        public DateTime TijdToegevoegd { get; set; }
        public MediaType MediaType { get; set; }
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
        public string Display()
        {
            return $"<div><a href=\"{Adress}\" target=\"_blank\">{Naam}</a></div>";
        }
    }
}
