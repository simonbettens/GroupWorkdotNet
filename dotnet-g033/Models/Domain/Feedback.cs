using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Feedback
    {
        public int Id { get; set; }
        public string GebruikerUserName { get; set; }
        public int AantalSterren { get; set; }
        public string Inhoud { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime TijdToegevoegd { get; set; }

        public Feedback(int aantalSterren, DateTime tijdToegevoegd, string voornaam, string achternaam, string gebruikerUserName, string inhoud = "")
        {
            this.AantalSterren = aantalSterren;
            this.TijdToegevoegd = tijdToegevoegd;
            this.Inhoud = inhoud;
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.GebruikerUserName = gebruikerUserName;
        }

        public int ToonAantalSterren()
        {
            return AantalSterren;
        }

        public string ToonComment()
        {
            return Inhoud;
        }

        public void EditComment(string input)
        {
            Inhoud = input;
        }

        public bool HeeftInhoud()
        {
            return this.Inhoud != "";
        }
    }
}
