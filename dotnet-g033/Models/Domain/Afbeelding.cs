using System;

namespace dotnet_g033.Models.Domain
{
    public class Afbeelding :Media
    {
        public Afbeelding()
        {

        }
        public Afbeelding(String adress, String naam, DateTime tijdToegevoegd, MediaType mediaType)
        {
            this.Adress = adress;
            this.Naam = naam;
            this.TijdToegevoegd = tijdToegevoegd;
            this.MediaType = mediaType;
        }
        
    }
}
