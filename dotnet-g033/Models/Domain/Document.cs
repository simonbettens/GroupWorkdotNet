using System;

namespace dotnet_g033.Models.Domain
{
    public class Document : Media
    {
        public Document()
        {

        }
        public Document(string adress, string naam, DateTime toegevoegd, MediaType mediaType)
        {
            this.Adress = adress;
            this.Naam = naam;
            this.TijdToegevoegd = toegevoegd;
            this.MediaType = mediaType;
        }
        
    }
}
